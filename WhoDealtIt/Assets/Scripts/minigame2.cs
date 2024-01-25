using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame2 : MonoBehaviour
{
    [SerializeField] private GameObject candle1;
    [SerializeField] private GameObject candle2;
    [SerializeField] private GameObject candle3;
    [SerializeField] private GameObject candle4;
    [SerializeField] private GameObject candle5;
    [SerializeField] private GameObject canvas;

    private int index;

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        if (index == 5)
        {
            canvas.SetActive(false);
        }
    }

    public void buttonPressed1()
    {
        candle1.SetActive(false);
        ++index;
    }
    public void buttonPressed2()
    {
        candle2.SetActive(false);
        ++index;
    }
    public void buttonPressed3()
    {
        candle3.SetActive(false);
        ++index;
    }
    public void buttonPressed4()
    {
        candle4.SetActive(false);
        ++index;
    }
    public void buttonPressed5()
    {
        candle5.SetActive(false);
        ++index;
    }

}
