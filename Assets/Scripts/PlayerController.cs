using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{
    private const int DEFAULTCANDLENUM = 3;
    private bool m_isAxisInUse = false;
    private CircleCollider2D candle;
    public int candleAmount = DEFAULTCANDLENUM;
    public bool movementControl;

    protected override void Start()
    {
        enabled = true;
        candle = GameObject.Find("CandleTrigger").GetComponent<CircleCollider2D>();
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
            candle.enabled = true;
            FindObjectOfType<Candles>().removeCandle();
            candleAmount -= 1;
        }
    }

    protected override void Move(int x, int y)
    {
        candle.enabled = false;
        GameManager.instance.playersTurn = false;
        base.Move(x, y);
    }

    public void SetMovementControl(bool controlBool) {
        movementControl = controlBool;
    }

}

