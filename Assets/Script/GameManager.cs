using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.MixedReality.Toolkit.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameMenu;
    public EnemiesSpawner spawner;
    public GameObject overHead;
    public GameObject scoreMenu;

    public ToolTip toolTip;
    public ToolTip scoreToolTip;

    public ScoreSO scoreSO;

    private void Start()
    {
        //Subscribe to game finished event
        spawner.onGameFinished += EndGame;
    }

    public void StartGame()
    {
        //Score
        scoreSO.currentScore = 0;

        spawner.StartGame();
        toolTip.ToolTipText = "Protect the sphere!!";
        Invoke("DisableMenu", 5);   
    }

    public void EndGame()
    {
        //Score
        if (scoreSO.currentScore > scoreSO.highScore)
        {
            scoreSO.highScore = scoreSO.currentScore;
        }

        Invoke("EnableMenu", 1);
    }

    void DisableMenu()
    {
        gameMenu.SetActive(false);
        overHead.SetActive(false);
        scoreMenu.SetActive(false);
    }

    //TODO: Score
    void EnableMenu()
    {
        gameMenu.SetActive(true);
        overHead.SetActive(true);
        scoreMenu.SetActive(true);
        toolTip.ToolTipText = "Thank you for playing";
        scoreToolTip.ToolTipText = String.Format("Score: {0}",scoreSO.currentScore);
    }
}
