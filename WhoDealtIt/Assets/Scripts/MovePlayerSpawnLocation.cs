using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayerSpawnLocation : MonoBehaviour
{
    public void MansionSpawn()
    {
        if (SceneManager.GetActiveScene().name == "Mansion")
        {
            MoveplayerlocationsMansion();
        }
    }

    private void MoveplayerlocationsMansion()
    {
        if (PhotonNetwork.isMasterClient)
        {
            transform.position = new Vector2(1001f, 652f);
        }
        else if (PhotonNetwork.player.ID == 1002)
        {
            transform.position = new Vector2(350f, 652f);
        }
        else if (PhotonNetwork.player.ID == 1003)
        {
            transform.position = new Vector2(665f, 652f);
        }
        else if (PhotonNetwork.player.ID == 1004)
        {
            transform.position = new Vector2(1400f, 652f);
        }
        else if (PhotonNetwork.player.ID == 1005)
        {
            transform.position = new Vector2(1805f, 652f);
        }
    }
}
