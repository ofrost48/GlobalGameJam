using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonVieww;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject playerCamera;
    public SpriteRenderer sr;
    public TMP_Text playerNameText;

    public float moveSpeed;
    float horizontalInput;
    float verticalInput;
    Vector2 moveDirection;
    float xDirection;
    float yDirection;

    private void Awake()
    {
        rb.gravityScale = 0.0f;
        moveSpeed = 150f;
        xDirection = 0.0f;
        yDirection = 0.0f;

        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
            playerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            playerNameText.text = photonView.owner.name;
            playerNameText.color = Color.white;
        }
    }

  

    private void FixedUpdate()
    {
        if (photonView.isMine)
        {
            CheckInput();
            MovePlayer();
        }
    }

    private void CheckInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (xDirection != horizontalInput)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            xDirection = horizontalInput;
        }

        if (yDirection != verticalInput)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            yDirection = verticalInput;
        }
    }

    private void MovePlayer()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        { 

            photonView.RPC("AddVelocity", PhotonTargets.AllBuffered);
        }
        else
        {
            photonView.RPC("Vector2Zero", PhotonTargets.AllBuffered);
        }
    }

    [PunRPC]
    public void AddVelocity()
    {
        moveDirection = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        rb.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    [PunRPC]
    private void Vector2Zero()
    {
        rb.velocity = Vector2.zero;
    }
}
