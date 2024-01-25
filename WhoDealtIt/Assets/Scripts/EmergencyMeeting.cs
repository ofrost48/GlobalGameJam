using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmergencyMeeting : MonoBehaviour
{

    public GameObject pressBlank;
    public GameObject emergency;
    public GameManager gameManager;
    public GameObject localPlayer;

    private void Awake()
    {
        GameObject localPlayer = GameObject.Find("Player(Clone)");
    }

    private void Update()
    {
        PressingButton();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            pressBlank.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            pressBlank.SetActive(false);
    }

    private void PressingButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            emergency.SetActive(true);
            gameManager.MansionSpawner();
            Invoke("Removeemergency", 2);
        }
    }

        private void Removeemergency()
    {
        emergency.SetActive(false);
    }
}
