using System;
using System.Collections;
using System.Collections.Generic;
using JumpFrog;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum State
{
    Start,
    Playing,
    Lose,
}

public class GameManager : Singleton<GameManager>
{
    public State currentState = State.Start;

    public GameObject loseObj;

    public TextMeshProUGUI point, highPoint;

    public GameObject tap;
    public GameObject tap1;

    public GameObject[] respawns;

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Restart(bool up)
    {
        if (up)
        {
            DirGameDataManager.Ins.playerData.LevelUP();
        }

        SceneManager.LoadScene("Game");
    }

    void Start()
    {
        SetState(State.Playing);
        tap.SetActive(false);
        tap1.SetActive(true);
        SpawnEnemy.Instance.Spawn();
    }

    void Update()
    {
       
    }

    private bool CheckWin()
    {
        return true;
    }

    public void MoveColor(TesterTube tube)
    {
    }


    public void Help()
    {
    }

    public void ShowLose()
    {
        loseObj.SetActive(true);

        SetState(State.Lose);

        point.SetText($"Your Score : {TheLevelTMP.Instance.point}");

        DirGameDataManager.Ins.playerData.SetPoint(TheLevelTMP.Instance.point);

        highPoint.SetText($"Best Score : {DirGameDataManager.Ins.playerData.point}");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Continue()
    {
        if (DirGameDataManager.Ins.playerData.intHelp >= 10)
        {
            DirGameDataManager.Ins.playerData.SubHelp(10);
            loseObj.SetActive(false);

            respawns = GameObject.FindGameObjectsWithTag("Enemy");

            if (respawns != null)
            {
                foreach (GameObject respawn in respawns)
                {
                    Destroy(respawn);
                }
            }

            SetState(State.Playing);
        }
    }

    public Sprite[] sprites;
    public Image currentImage, nextImage;
    
    public void ShowCurrentImage(int rand)
    {
        currentImage.sprite = sprites[rand];
        currentImage.SetNativeSize();
    }

    public void ShowNextImage(int nextRand)
    {
        nextImage.sprite = sprites[nextRand];
        nextImage.SetNativeSize();
    }
}