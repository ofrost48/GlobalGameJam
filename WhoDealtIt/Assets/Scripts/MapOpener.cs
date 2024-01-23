using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MapOpener : MonoBehaviour
{
    public GameObject Map;
    public PostProcessVolume blur;
    public GameObject playerCam;

    private bool isActive;

    private void Awake()
    {
        Map.SetActive(false);
        isActive = false;
        blur.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            blur.enabled = !blur.enabled;

            if (isActive == false)
            {
                Map.SetActive(true);
                isActive = true;
            }
            else if (isActive == true)
            {
                Map.SetActive(false);
                isActive = false;
            }

        }
    }



}
