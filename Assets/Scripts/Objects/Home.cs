using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // public Text enterHome;
    //public AudioClip victoryMusic;
    //[SerializeField] [Range(0, 1)] float volume = 1f;

    AudioSource bgm;

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
        bgm.Stop();
    }

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
        GameObject bubble = GameObject.Find("Bubble");
        if (bubble != null)
        {   
            bubble.SetActive(false);
        }
        GameObject bgmObject = GameObject.Find("GameBGM");
        if (bgmObject != null)
        {
            Destroy(bgmObject);
            bgm.Play();
        }
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.YouWin();
        // SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }

}
