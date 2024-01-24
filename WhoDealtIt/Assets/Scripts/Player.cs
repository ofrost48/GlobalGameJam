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

    private void Awake()
    {
        rb.gravityScale = 0.0f;
        moveSpeed = 150f;

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

        DontDestroyOnLoad(gameObject);
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

    [PunRPC]
    public void MoveplayerlocationsMansion()
    {
        Debug.Log("MANSION WORKS");

        if (PhotonNetwork.player.ID == 1001)
        {
            transform.position = new Vector2(1001f, 652f);
        }
        else if (PhotonNetwork.player.ID == 2001)
        {
            transform.position = new Vector2(350f, 652f);
        }
        else if (PhotonNetwork.player.ID == 3001)
        {
            transform.position = new Vector2(665f, 652f);
        }
        else if (PhotonNetwork.player.ID == 4001)
        {
            transform.position = new Vector2(1400f, 652f);
        }
        else if (PhotonNetwork.player.ID == 5001)
        {
            transform.position = new Vector2(1805f, 652f);
        }
    }
}
