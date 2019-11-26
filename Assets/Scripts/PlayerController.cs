using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{

    public Animator animator;

    protected override void Start()
    {
        enabled = true;

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

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

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
        else if (horizontal == 0 && vertical == 0) {
            animator.SetTrigger("Idle");
        }

    }

    protected override void Move(int x, int y)
    {
        GameManager.instance.playersTurn = false;
        base.Move(x, y);
        if (x>0) {
            animator.SetTrigger("MoveRight");
        }
        else if (x<0) {
            animator.SetTrigger("MoveLeft");
        }
        else if (y>0) {
            animator.SetTrigger("MoveUp");
        }
        else if (y<0) {
            animator.SetTrigger("MoveDown");
        }
    }




    private void CheckIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        if (!enabled)
        {
            //Call the GameOver function of GameManager.
            GameManager.instance.GameOver();
        }
    }

}

