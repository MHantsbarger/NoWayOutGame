using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    //public Text prompts;
    //private float amount = 0;
    //private float currentAmount = 0;
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
            temp = (Image)Instantiate(trap);
            temp.GetComponent<Transform>().SetParent(GameObject.Find("Bubble").GetComponent<Transform>(), true);
            temp.transform.position = GameObject.Find("Bubble").GetComponent<Transform>().position + 
                new Vector3(GameObject.Find("Player 1").GetComponent<PlayerController>().TrapInitialPosX, 10, 0);
            GameObject.Find("Player 1").GetComponent<PlayerController>().TrapInitialPosX += 35;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bubble.enabled = false;
        GameObject.Find("Player 1").GetComponent<PlayerController>().TrapInitialPosX = -33;
        List<GameObject> trapicon = sameName("TrapIcon(Clone)");
        foreach (GameObject go in trapicon)
        {
            Destroy(go);
        }
        Destroy(temp);
    }
    private List<GameObject> sameName(string iconName)
    {
        List<GameObject> obj = new List<GameObject>();
        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)))
        {

            if (go.name == iconName)
            {
                obj.Add(go);
            }
        }
        return obj;
    }
}
