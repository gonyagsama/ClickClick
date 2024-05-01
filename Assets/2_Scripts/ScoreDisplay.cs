using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{


    void Start()
    {
        GetComponent<Text>().text = "BestTime : " + GameManager.minTime;
        Debug.Log("1BestTime : " + GameManager.minTime);

        float minTime = PlayerPrefs.GetFloat("minTime", 1000f);
        Debug.Log("2BestTime : " + minTime);
    }

    void Update()
    {
        
    }
}
