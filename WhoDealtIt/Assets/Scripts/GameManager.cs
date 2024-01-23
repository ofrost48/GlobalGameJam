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

    public GameObject PlayerFeed;
    public GameObject FeedGrid;
    public GameObject Ping;

    public GameObject SettingsUI;

    private bool PingOn = false;

    public static bool ChangedPingOption = false;

    private void Awake()
    {
        if(GameCanvas != null)
        {
            GameCanvas.SetActive(true);
        }
    }

    // Gets Input
    // Gets Ping
    private void Update()
    {
        CheckInput();
        if(Ping != null)
        {
            PingText.text = "PING:" + PhotonNetwork.GetPing();
        }
        

    }

    //Open PauseUI
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

    // Start Button to Spawn Player
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f,1f);

        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);

        if(ChangedPingOption)
        {
            SettingsUI.GetComponentInChildren<Toggle>().isOn = true;
        }
    }

    // PauseMenu UI

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Menu");
    }

    public void OpenSettings()
    {
        SettingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
    }

    // SettingsMenu UI

    public void TogglePing()
    {

        if (PingOn)
        {
            Ping.SetActive(false);
            PingOn = false;
        }  
        else
        {
            Ping.SetActive(true);
            PingOn = true;

        }
    }


    // Join/Leave Show on left

    private void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity); 
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<TMP_Text>().text = player.name + " left the game";
        obj.GetComponent<TMP_Text>().color = Color.green;
    }

    private void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
        obj.transform.SetParent(FeedGrid.transform, false);
        obj.GetComponent<TMP_Text>().text = player.name + " left the game";
        obj.GetComponent<TMP_Text>().color = Color.red;
    }
}

