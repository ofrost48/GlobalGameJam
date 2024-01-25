using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame4 : MonoBehaviour
{
    [SerializeField] private Slider throttleSlider;
    [SerializeField] private GameObject canvas;
    private bool switch1on;
    private bool switch2on;
    private float throttle;

    private void Start()
    {
        switch1on = false;
        switch2on = false;
        throttle = 0;
    }

    public void switch1()
    {
        switch1on = !switch1on;
    }
    public void switch2()
    {
        switch2on = !switch2on;
    }
    public void throttleVal()
    {
        throttle = throttleSlider.value;
    }

    private void Update()
    {
        if((switch1on == true) && (switch2on == true) && (throttle == 1))
        {
            canvas.SetActive(false);
        }
    }
}
