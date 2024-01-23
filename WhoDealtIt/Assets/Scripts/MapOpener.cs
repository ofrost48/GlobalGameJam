using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapOpener : MonoBehaviour
{

    private Inputs input = null;
    private bool isOpen = false;

    private void Awake()
    {
        input = new Inputs();
        input.MapAction.OpenMap.performed += x => MapPressed();
        input.MapAction.CloseMap.performed += x => MapReleased();
    }

    private void MapPressed()
    {
        isOpen = true;
    }

    private void MapReleased()
    {
        isOpen = false;
    }


}
