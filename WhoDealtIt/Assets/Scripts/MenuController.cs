using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string versionName = " 0.1 ";
    [SerializeField] private GameObject usernameCanvas ;
    [SerializeField] private GameObject multiplayerCanvas ;

    [SerializeField] private GameObject LobbyFullTxt;

    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField createGameInput;
    [SerializeField] private TMP_InputField joinGameInput;

    [SerializeField] private GameObject startButton;

    public GameObject SettingsUI;
    private bool PingOff = false;

    private int minCharacterAmountUSR = 3;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
    }

    private void Start()
    {
        usernameCanvas.SetActive(true);
        usernameInput.characterLimit = 12;
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput()
    {
        if (usernameInput.text.Length >= minCharacterAmountUSR)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        usernameCanvas.SetActive(false);
        PhotonNetwork.playerName= usernameInput.text;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(createGameInput.text, new RoomOptions() { MaxPlayers = 5 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(joinGameInput.text, roomOptions, TypedLobby.Default);

        if (PhotonNetwork.countOfPlayers >= 5)
        {
            LobbyFullTxt.SetActive(true);
            Invoke("LobbyFullDissapear", 3);
        }
    }

    private void LobbyFullDissapear()
    {
        LobbyFullTxt.SetActive(false);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuitGamne_Success");

    }

    public void OpenSettings()
    {
        SettingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
    }

}
