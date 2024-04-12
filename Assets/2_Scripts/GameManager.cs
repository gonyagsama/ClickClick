using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf )
                return true;
            else
                return false;
        }
        
    }
    public void CalculateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.instance.CreateNoteGroup();

            }

            if (maxScore <= score)
            {
                gameClearObj.SetActive(true);
            }
        }
        else
        {
            score--;
        }

        Debug.Log("Score : " + score);

        UiManager.instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        Debug.Log("Game Restart!... ... ...");
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
        Instance = this;
       
    }

    private void Start()
    {
        UiManager.instance.OnScoreChange(score, maxScore);
        NoteManager.instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);

        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UiManager.instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        //GameOver
        gameOverObj.SetActive(true);
    }
}

