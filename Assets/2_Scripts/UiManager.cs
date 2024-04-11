using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private Image scorelmg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI timerTmp;

    private void Awake()
    {
        instance = this;
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scorelmg.fillAmount = (float)currentScore / maxScore;
    }
    public void OnTimerChange(float currentTimer, float maxTimer)
    {
        timerTmp.text = $"{currentTimer:N1}/{maxTimer:N1}";
        timerImage.fillAmount = (float)currentTimer / maxTimer;
    }
}
