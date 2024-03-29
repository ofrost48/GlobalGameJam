using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame3 : MonoBehaviour
{
    [SerializeField] private Slider pillow1;
    [SerializeField] private Slider pillow2;
    [SerializeField] private Slider sheet;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Collider2D bedCollider;
    [SerializeField] private GameObject bedImage;

    private float slider1;
    private float slider2;
    private float slider3;

    public int windex = 0;


    void Start()
    {
        slider1 = 0f;
        slider2 = 0f;   
        slider3 = 0f;
    }

    void Update()
    {
        if((slider1 == 1) && (slider2 == 1) && (slider3 == 1))
        {
            canvas.SetActive(false);
            bedImage.SetActive(true);
        }
    }

    public void setSlider1()
    {
        slider1 = pillow1.value;
    }
    public void setSlider2()
    {
        slider2 = pillow2.value;
    }
    public void setSlider3()
    {
        slider3 = sheet.value;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        canvas.SetActive(true);
        bedCollider.enabled = false;

       
    }



}
