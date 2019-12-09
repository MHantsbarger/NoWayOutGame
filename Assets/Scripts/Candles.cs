using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candles : MonoBehaviour
{

    public GameObject[] candles;
    private int numOfCandles;

    // Start is called before the first frame update
    void Start()
    {
        numOfCandles = FindObjectOfType<PlayerController>().candleAmount;
    }


    public void removeCandle()
    {
        if (numOfCandles > 0)
        {
            numOfCandles--;
            candles[numOfCandles].SetActive(false);
        }
    }
}
