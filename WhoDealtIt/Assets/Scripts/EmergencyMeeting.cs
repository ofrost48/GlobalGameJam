using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmergencyMeeting : MonoBehaviour
{

    public GameObject pressBlank;
    public GameObject emergency;
    public GameManager gameManager;
    public GameObject emergencyNoise;
 

    public bool cooldown = false;

    private void Awake()
    {
  
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
        if (!cooldown & Input.GetKeyDown(KeyCode.E))
        {
            emergency.SetActive(true);
            gameManager.MansionSpawner();
            emergencyNoise.GetComponent<AudioSource>().Play();
            cooldown = true;
            Invoke("CooldownReset", 20);
            Invoke("Removeemergency", 2);
        }
    }

        private void Removeemergency()
    {
        emergency.SetActive(false);
    }

    private void CooldownReset() 
    { 
        cooldown = false; 
    
    }

}
