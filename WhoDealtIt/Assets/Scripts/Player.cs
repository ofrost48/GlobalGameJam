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

    public bool isImposter = true;
    public bool canAttackPlayer = false;
    public GameObject otherPlayer;

    public float moveSpeed;
    float horizontalInput;
    float verticalInput;
    Vector2 moveDirection;

    private float spawnPosition;

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

    private void Update()
    {
        if ((horizontalInput != 0) || (verticalInput != 0))
        {
            photonView.RPC("CheckIsMovingAnimTrue", PhotonTargets.AllBuffered);
        }
        else
        {
            photonView.RPC("CheckIsMovingAnimFalse", PhotonTargets.AllBuffered);
        }
        if (horizontalInput < 0)
        {
            photonView.RPC("TrytoFlipTrue", PhotonTargets.AllBuffered);
        }
        else if (horizontalInput > 0)
        {
            photonView.RPC("TrytoFlipFalse", PhotonTargets.AllBuffered);
        }
        if (Input.GetKeyDown(KeyCode.F) && isImposter && canAttackPlayer)
        {
            //otherPlayer.GetComponent<SpriteRenderer>().color = ;
            //kill other player
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

        if (Input.GetKeyDown(KeyCode.F) && isImposter && canAttackPlayer)
        {
            if (otherPlayer != null)
            {
                Debug.Log("killed other player: " + otherPlayer.name);
                //complete killing of otherPlayer
            }
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

    [PunRPC]
    public void MansionSpawn()
    {
        photonView.RPC("MansionSpawnLocation", PhotonTargets.AllViaServer);
    }

    [PunRPC]
    public void MansionSpawnLocation()
    {
        UnityEngine.Debug.Log("Spawned at the mansion");

        float[] spawnPositions = { 400f, 640f, 900f, 1160f, 1430f};
        int i = 0;

        GameObject[] playersInScene = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in playersInScene)
        {
            UnityEngine.Debug.Log(player.transform.position);
            player.transform.position = new Vector2(spawnPositions[i], 560);
            i++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ontriggerenter");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Can attack player");
            canAttackPlayer = true;
            otherPlayer = collision.gameObject;
            Debug.Log(otherPlayer);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("ontriggerexit");
        if (collision.CompareTag("Player"))
        {
            canAttackPlayer = false;
            otherPlayer = null;
        }
    }

    [PunRPC]
    private void TrytoFlipTrue()
    {
        sr.flipX = true;
    }

    [PunRPC]
    private void TrytoFlipFalse()
    {
        sr.flipX = false;
    }

    [PunRPC]
    private void CheckIsMovingAnimTrue()
    {
        anim.SetBool("isMoving", true);
    }

    [PunRPC]
    private void CheckIsMovingAnimFalse()
    {
        anim.SetBool("isMoving", false);
    }

}
