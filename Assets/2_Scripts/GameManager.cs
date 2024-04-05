using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    private int score;

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
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
    }
}

