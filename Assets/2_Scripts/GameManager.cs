using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;

    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

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
        }
        else
        {
            score--;
        }

        Debug.Log("Score : " + score);

        UiManager.instance.OnScoreChange(score, maxScore);
    }
    private void Awake()
    {
        Instance = this;
       
    }

    private void Start()
    {
        UiManager.instance.OnScoreChange(score, maxScore);
        NoteManager.instance.Create();

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
        }

        Debug.Log("Game Over...");
    }
}

