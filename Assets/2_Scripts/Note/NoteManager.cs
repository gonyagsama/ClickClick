using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private GameObject noteGrouoPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    public static NoteManager instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();



    private void Awake()
    {
        instance = this;
    }

    public void Create()
    {
        foreach(KeyCode keyCode in initKeyCodeArr)
        {
            CreateNoteGroup(keyCode);
        }
    }

    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGrouoPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupList.Count);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }
    }
}
