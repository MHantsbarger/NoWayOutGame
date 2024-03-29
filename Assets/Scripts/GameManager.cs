﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float turnDelay = 0.1f; // how long the game wait between turns

    public Text prompts;

    private Text tempText;

    private GameObject winLoseWindow;
    private Text winLoseText;

    // 能让外部访问这个类的这个变量
    public static GameManager instance = null;

    [HideInInspector] public BoardManager boardScript;

    [HideInInspector] public bool playersTurn = true;

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

        boardScript = GetComponent<BoardManager>();
        winLoseWindow = GameObject.Find("WinLoseWindow");
        winLoseText = GameObject.Find("WinLoseText").GetComponent<Text>();
        winLoseWindow.SetActive(false);
        InitGame();
    }

    private void InitGame()
    {
        prompts.text = "";
        tempText = (Text)Instantiate(prompts);
        tempText.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), true);
        tempText.transform.position = GameObject.Find("Canvas").transform.position + new Vector3(0, -140, 0);
        tempText.text = prompts.text;
        prompts.raycastTarget = false;
        boardScript.SetupScene();
    }



    public void GameOver()
    {
        // enabled = false; // disable the gameManager
        winLoseText.text = "You Lose!";
        prompts.text = "";
        winLoseWindow.SetActive(true);
    }
    public void YouWin()
    {
        // enabled = false; // disable the gameManager
        winLoseText.text = "You Win!";
        prompts.text = "";
        winLoseWindow.SetActive(true);
    }

    void Update()
    {
        if (playersTurn)
        {
            return;
        }
        tempText.text = prompts.text;
    }

}

