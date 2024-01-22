using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonVieww;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject playerCamera;
    public SpriteRenderer sr;
    public Text playerNameText;

    //Movement Script Variables Go Hear

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
        }
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
        // Movement Script Goes Here
    }
}

   
