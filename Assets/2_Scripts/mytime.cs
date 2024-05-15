using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mytime : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "현재 기록 : " + GameManager.myTime.ToString("N0");
    }

    void Update()
    {
        
    }
}
