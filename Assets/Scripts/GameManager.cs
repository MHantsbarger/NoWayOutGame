using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float turnDelay = 0.1f; // how long the game wait between turns

    // 能让外部访问这个类的这个变量
    public static GameManager instance = null;

    [HideInInspector] public BoardManager boardScript;

    [HideInInspector] public bool playersTurn = true; //HideInInspector: Although the variable is public, it won't be displayed in editor

    // Start is called before the first frame update
    void Awake()
    {
        // check if instance already exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); // Sets this to not be destroyed when reloading scene
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    private void InitGame()
    {
        boardScript.SetupScene();
    }

    public void GameOver()
    {
        enabled = false; // disable the gameManager
    }

    //IEnumerator MoveDelay()
    //{
    //    yield return new WaitForSeconds(turnDelay);
    //    playersTurn = true;
    //}

    void Update()
    {
        if (playersTurn)
        {
            return;
        }
        //StartCoroutine(MoveDelay());
    }

}
