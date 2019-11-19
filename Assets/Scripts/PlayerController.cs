using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MovingObject
{
<<<<<<< HEAD


    //public Text prompts;
    //public Text FailText; 
=======

    [SerializeField] private float speed = 10.0f;

    public Text prompts;
    public Text FailText;
    private Rigidbody2D rb;
    private Vector3 target;
    private Transform tr;
>>>>>>> 57d25697cf133b08a49588fe1b2af42c64a79364

    protected override void Start()
    {
<<<<<<< HEAD
        base.Start();
=======
        rb = GetComponent<Rigidbody2D>();
        target = new Vector3(-3.5f, -4.5f);
        tr = transform;
>>>>>>> 57d25697cf133b08a49588fe1b2af42c64a79364
    }

    void Update()
    {
<<<<<<< HEAD
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
=======
        Move();
    }

    private void Move()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime));

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
>>>>>>> 57d25697cf133b08a49588fe1b2af42c64a79364
        }

        if (horizontal != 0 || vertical != 0)
        {
            Move(horizontal, vertical);
            GameManager.instance.playersTurn = false;
        }

    }

<<<<<<< HEAD


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
=======
    void OnTriggerExit2D(Collider2D collision)
    {
        prompts.text = " ";
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && tr.position == target)
        {
            var xPos = Mathf.Clamp(transform.position.x + 1, -4.5f, 4.5f);
            var yPos = transform.position.y;
            target = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tr.position == target)
        {
            var xPos = Mathf.Clamp(transform.position.x - 1, -4.5f, 4.5f);
            var yPos = transform.position.y;
            target = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && tr.position == target)
        {
            var xPos = transform.position.x;
            var yPos = Mathf.Clamp(transform.position.y + 1, -4.5f, 4.5f);
            target = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && tr.position == target)
        {
            var xPos = transform.position.x;
            var yPos = Mathf.Clamp(transform.position.y - 1, -4.5f, 4.5f);
            target = new Vector2(xPos, yPos);
        }


        
    }
>>>>>>> 57d25697cf133b08a49588fe1b2af42c64a79364
}
