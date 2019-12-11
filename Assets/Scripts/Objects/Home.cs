using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // public Text enterHome;
    public AudioClip victoryMusic;
    [SerializeField] [Range(0, 1)] float volume = 1f;

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
        PlayerController playerController =  player.GetComponent<PlayerController>();
        playerController.SetMovementControl(false);
        Animator animatorObject = player.GetComponent<Animator>();
        animatorObject.SetTrigger("FoundHome");
        GameObject bgmObject = GameObject.Find("GameBGM");
        AudioSource bgm = bgmObject.GetComponent<AudioSource>();
        bgm.Stop();
        bgm.clip = victoryMusic;
        bgm.Play();
        // bgm.Play();
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.YouWin();
        // SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

}
