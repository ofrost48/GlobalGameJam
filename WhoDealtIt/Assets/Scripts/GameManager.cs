using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    public TMP_Text PingText;
    public GameObject PauseUI;
    private bool Off = false;

    private void Awake()
    {
        GameCanvas.SetActive(true);
    }

    private void Update()
    {
        CheckInput();
        PingText.text = "PING:" + PhotonNetwork.GetPing();
    }

    private void CheckInput()
    {
        if(Off && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(false);
            Off = false;
        }
        else if (!Off && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            Off = true;
        }
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f,1f);

        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Menu");
    }

}

