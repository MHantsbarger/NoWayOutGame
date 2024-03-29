﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{
    private const int DEFAULTCANDLENUM = 3;
    private bool m_isAxisInUse = false;
    private BoxCollider2D candle;
    [HideInInspector] public int candleAmount = DEFAULTCANDLENUM;
    [HideInInspector] public bool movementControl;

    [SerializeField] AudioClip walkingSound;
    [SerializeField] [Range(0, 1)] float walkingSoundVolume = 1f;
    [SerializeField] AudioClip candleSound;
    [SerializeField] [Range(0, 1)] float candleSoundVolume = 1f;
    
    protected override void Start()
    {
        enabled = true;
        candle = GameObject.Find("CandleTrigger").GetComponent<BoxCollider2D>();

        movementControl = true;
        base.Start();
    }

    void Update()
    {


        if (!GameManager.instance.playersTurn)
        {
            return;
        }
        int horizontal = 0;
        int vertical = 0;

        if (movementControl && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            if(m_isAxisInUse == false)
            {
                horizontal = (int)(Input.GetAxisRaw("Horizontal"));
                vertical = (int)(Input.GetAxisRaw("Vertical"));
                m_isAxisInUse = true;
            }
        }
        if( Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            m_isAxisInUse = false;
        }    

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (horizontal != 0 || vertical != 0)
        {
            GameManager.instance.playersTurn = false;
            Move(horizontal, vertical);
        }
        if (movementControl && Input.GetKeyDown(KeyCode.Space) && candleAmount > 0) {
            //candle.enabled = true;
            FindObjectOfType<Candles>().removeCandle();
            AudioSource.PlayClipAtPoint(candleSound, transform.position, candleSoundVolume);
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Fog"))
            {
                if (go.GetComponent<Fog>().preToDie) {
                    go.SetActive(false);
                }
            }
            candleAmount -= 1;
        }
    }

    protected override void Move(int x, int y)
    {
        //candle.enabled = false;
        GameManager.instance.playersTurn = false;
        base.Move(x, y);
        AudioSource.PlayClipAtPoint(walkingSound, transform.position, walkingSoundVolume);
    }

    public void SetMovementControl(bool controlBool) {
        movementControl = controlBool;
    }

}

