using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;

    public Text prompts;
    public Text FailText;
    private Rigidbody2D rb;
    private Vector2 target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = new Vector2(-3.5f, -4.5f);
    }

    void Update()
    {
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
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        prompts.text = " ";
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var xPos = Mathf.Clamp(transform.position.x + 1, -4.5f, 4.5f);
            var yPos = transform.position.y;
            target = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var xPos = Mathf.Clamp(transform.position.x - 1, -4.5f, 4.5f);
            var yPos = transform.position.y;
            target = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var xPos = transform.position.x;
            var yPos = Mathf.Clamp(transform.position.y + 1, -4.5f, 4.5f);
            target = new Vector2(xPos, yPos);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var xPos = transform.position.x;
            var yPos = Mathf.Clamp(transform.position.y - 1, -4.5f, 4.5f);
            target = new Vector2(xPos, yPos);
        }
    }
}
