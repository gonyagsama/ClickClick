using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    public void Start()
    {
        Debug.Log($"mytime" + GameManager.myTime);
        Debug.Log($"mintime" + GameManager.minTime);

        Debug.Log($"GameOver : {GameManager.Instance.IsGameOver()}, GameClear : {GameManager.Instance.IsGameClear()}");
    }
    public void Replay()
    {
        
        SceneManager.LoadScene("PlayScenes");
    }
}
