using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour
{
    [SerializeField] private Slider plungerDepth;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject imageClean;
    [SerializeField] private GameObject imageDirty;


    private bool swapCurrent;
    private float sliderVal;
    private int index;

    public void Start()
    {
        swapCurrent = true;
        index = 0;

    }

    public void SetValFromSlider()
    {
        sliderVal = plungerDepth.value;
    }

    public void Update()
    {

        if (swapCurrent == true) 
        {
            if(sliderVal == 1)
            {
                swapCurrent = !swapCurrent;
                ++index;
            }
        }

        else if (swapCurrent == false)
        {
            if(sliderVal == 0)
            {
                swapCurrent = !swapCurrent;
                ++index;
            }
        }

        if(index == 10)
        {
            canvas.SetActive(false);
            imageClean.SetActive(true);
            imageDirty.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        canvas.SetActive(true);
    }



}
