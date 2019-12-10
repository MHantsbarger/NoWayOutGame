using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerInGame : MonoBehaviour
{
    void Awake()
    {
        Destroy(MusicPlayer.Instance.gameObject);
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }
}
