using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    private GameObject player;
    private int amount;
    private Fog fog;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player 1");
        amount = player.GetComponent<PlayerController>().candleAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && amount > 0 && player.GetComponent<PlayerController>().movementControl)
        {
           
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Fog"))
            {
                if (go.GetComponent<Fog>().preToDie) {
                    go.SetActive(false);
                }
            }
            amount -= 1;
        }
    }
}
