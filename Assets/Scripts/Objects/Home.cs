using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // public Text enterHome;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.CompareTag("Player"))
        {
            StartCoroutine(GameOver(player));
        }
    }

    IEnumerator GameOver(GameObject player)
    {
        // player.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.YouWin();
        // SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

}
