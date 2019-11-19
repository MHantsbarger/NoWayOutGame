using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{


    public Text prompts;
    public Text FailText; 

    

    protected override void Start()
    {

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

    }

    protected override void Move(int x, int y)
    {
        GameManager.instance.playersTurn = false;
        base.Move(x, y);


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject item = other.gameObject;
        if (item.CompareTag("Fog"))
        {
            Destroy(item);
        }
        if (item.CompareTag("Item"))
        {
            FailText.text = "Fail";
        }
        if (item.CompareTag("Traps"))
        {   
            if (prompts.text != " ")
            {
                prompts.text += "Trap" + "\n";
            }
            else
            {
                prompts.text = "Trap" + "\n";
            }
        }
        if (item.CompareTag("Plants"))
        {
            if (prompts.text != " ")
            {
                prompts.text += "Flower" + "\n";
            } 
            else
            {
                prompts.text = "Flower" + "\n";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        prompts.text = " ";
        FailText.text = " ";
    }


    //private void Restart()
    //{
    //    SceneManager.LoadScene(0);
    //}


}

