using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;

    public Text testText;
    private Rigidbody2D rb;
    private Vector2 target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = new Vector2(-4.5f, -4.5f);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.position = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "testItem")
        {
            testText.text = "Test Text";
        }
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
