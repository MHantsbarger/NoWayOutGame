using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDetector : MonoBehaviour
{
    public Text prompts;

    [SerializeField] AudioClip sound;
    [SerializeField] [Range(0, 1)] float volume = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position, volume);
            StartCoroutine(GameOver(player));
        }
    }

    IEnumerator GameOver(GameObject player)
    {
        // player.SetActive(false);
        PlayerController playerController =  player.GetComponent<PlayerController>();
        playerController.SetMovementControl(false);
        Animator animatorObject = player.GetComponent<Animator>();
        animatorObject.SetTrigger("Skeletonized");
        prompts.text = "";
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.GameOver();
        // SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}
