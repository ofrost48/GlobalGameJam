using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionSettiings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResIndex = 0;
    private bool fullscreen;

    public void Start()
    {
        //fullscreen stuff
        Screen.fullScreen = true;
        fullscreen = true;
        //

        //res stuff
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate==currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0;i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

         
    }

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        UnityEngine.Debug.Log("window change");
        fullscreen = !fullscreen;
    }

    public void SetRes(int resIndex)
    {
        Resolution resolution = filteredResolutions[resIndex];
        if(fullscreen == true)
        {
            Screen.SetResolution(resolution.width, resolution.height, true);

        }

        else if(fullscreen == false)
        {
            Screen.SetResolution(resolution.width, resolution.height, false);
        }
    }


}
