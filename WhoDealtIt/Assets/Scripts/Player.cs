using System.Collections;
using System.Collections.Generic;
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
    public Text playerNameText;

    public float moveSpeed;
    float horizontalInput;
    float verticalInput;
    Vector2 moveDirection;
    float xDirection;
    float yDirection;

    private void Awake()
    {
        rb.gravityScale = 0.0f;
        moveSpeed = 10f;

        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            CheckInput();
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
            rb.velocity = Vector3.zero;
            moveDirection = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

            rb.AddForce(moveDirection, ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}


