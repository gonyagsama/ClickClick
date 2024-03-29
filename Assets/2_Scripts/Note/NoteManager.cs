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

        if (keyCode == KeyCode.A)
        {
            noteGroupArr[0].OnInput(true);
        }
        if (keyCode == KeyCode.S)
        {
            noteGroupArr[1].OnInput(true);
        }
    }
}
