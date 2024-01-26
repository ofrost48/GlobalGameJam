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

    [SerializeField] private GameObject candle12;
    [SerializeField] private GameObject candle22;
    [SerializeField] private GameObject candle32;
    [SerializeField] private GameObject candle42;
    [SerializeField] private GameObject candle52;

    [SerializeField] private GameObject candle1real;
    [SerializeField] private GameObject candle2real;
    [SerializeField] private GameObject candle3real;
    [SerializeField] private GameObject candle4real;
    [SerializeField] private GameObject candle5real;

    [SerializeField] private GameObject candle1realLit;
    [SerializeField] private GameObject candle2realLit;
    [SerializeField] private GameObject candle3realLit;
    [SerializeField] private GameObject candle4realLit;
    [SerializeField] private GameObject candle5realLit;

    [SerializeField] private GameObject canvas;

    private int index;

    public int windex = 0;

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
        candle12.SetActive(true);
        candle1real.SetActive(false);
        candle1realLit.SetActive(true);
        ++index;
    }
    public void buttonPressed2()
    {
        candle2.SetActive(false);
        candle22.SetActive(true);
        candle2real.SetActive(false);
        candle2realLit.SetActive(true);
        ++index;
    }
    public void buttonPressed3()
    {
        candle3.SetActive(false);
        candle32.SetActive(true);
        candle3real.SetActive(false);
        candle3realLit.SetActive(true);
        ++index;
    }
    public void buttonPressed4()
    {
        candle4.SetActive(false);
        candle42.SetActive(true);
        candle4real.SetActive(false);
        candle4realLit.SetActive(true);
        ++index;
    }
    public void buttonPressed5()
    {
        candle5.SetActive(false);
        candle52.SetActive(true);
        candle5real.SetActive(false);
        candle5realLit.SetActive(true);
        ++index;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        canvas.SetActive(true);
    }

}
