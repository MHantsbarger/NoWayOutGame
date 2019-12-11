using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;
    //Scene scene = SceneManager.GetActiveScene();
    GameObject gameBGM;

    void Awake()
    {
        gameBGM = GameObject.Find("GameBGM");
        if (gameBGM != null)
        {
            Destroy(MusicPlayerInGame.instance.gameObject);
        }

        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
