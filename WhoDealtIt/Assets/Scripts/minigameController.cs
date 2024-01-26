using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigameController : MonoBehaviour
{
    [SerializeField] private Minigame1 game1;
    [SerializeField] private minigame2 game2;
    [SerializeField] private minigame3 game3;
    [SerializeField] private minigame4 game4;

    private int index = 0;

    private void Update()
    {
        index = (game1.windex + game2.windex + game3.windex + game4.windex);
        if (index == 4)
        {
            UnityEngine.Debug.Log("normal people win");
        }
    }

}
