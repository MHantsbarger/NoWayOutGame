using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerInGame : MonoBehaviour
{
    public static MusicPlayerInGame instance = null;
    GameObject menuBGM;

    void Awake()
    {
        menuBGM = GameObject.Find("MenuBGM");
        if (menuBGM != null)
        {
            Destroy(MusicPlayer.instance.gameObject);
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
            DontDestroyOnLoad(gameObject);
        }
    }
}
