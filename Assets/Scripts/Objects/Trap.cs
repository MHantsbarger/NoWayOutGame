using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{

    public Image trap;
    private Image bubble;
    private Image temp;


    public void Start()
    {
        bubble = GameObject.Find("Bubble").GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bubble.enabled = true;
            BubbleManager.instance.trapAmount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bubble.enabled = false;
        BubbleManager.instance.trapAmount = 0;
    }
}
