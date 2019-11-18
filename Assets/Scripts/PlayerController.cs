using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{


    //public Text prompts;
    //public Text FailText; 

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        //Move();
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
            Move(horizontal, vertical);
            GameManager.instance.playersTurn = false;
        }

    }



    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    GameObject item = other.gameObject;
    //    if (item.CompareTag("Fog"))
    //    {
    //        Destroy(item);
    //    }
    //    if (item.CompareTag("Item"))
    //    {
    //        FailText.text = "Fail";
    //    }
    //    if (item.CompareTag("Traps"))
    //    {   
    //        if (prompts.text != " ")
    //        {
    //            prompts.text += "Trap" + "\n";
    //        }
    //        else
    //        {
    //            prompts.text = "Trap" + "\n";
    //        }
    //    }
    //    if (item.CompareTag("Plants"))
    //    {
    //        if (prompts.text != " ")
    //        {
    //            prompts.text += "Flower" + "\n";
    //        } 
    //        else
    //        {
    //            prompts.text = "Flower" + "\n";
    //        }
    //    }

    //}

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    prompts.text = " ";
    //}

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    //void OnGUI()
    //{
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        var xPos = Mathf.Clamp(transform.position.x + 1, -4.5f, 4.5f);
    //        var yPos = transform.position.y;
    //        target = new Vector2(xPos, yPos);
    //    }
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        var xPos = Mathf.Clamp(transform.position.x - 1, -4.5f, 4.5f);
    //        var yPos = transform.position.y;
    //        target = new Vector2(xPos, yPos);
    //    }
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        var xPos = transform.position.x;
    //        var yPos = Mathf.Clamp(transform.position.y + 1, -4.5f, 4.5f);
    //        target = new Vector2(xPos, yPos);
    //    }
    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        var xPos = transform.position.x;
    //        var yPos = Mathf.Clamp(transform.position.y - 1, -4.5f, 4.5f);
    //        target = new Vector2(xPos, yPos);
    //    }
    //}
}
