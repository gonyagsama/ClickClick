using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
  
    public static NoteManager instance;
    [SerializeField] private NoteGroup[] noteGroupArr;



    private void Awake()
    {
        instance = this;
    }
    
   
    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupArr.Length);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupArr)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }
    }
}
