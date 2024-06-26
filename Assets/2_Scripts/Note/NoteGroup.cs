using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject noteSpwan;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private Animation anim;
    [SerializeField] private GameObject ap;
    [SerializeField] private GameObject ap2;


    private KeyCode keyCode;

    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();



    public void Create(KeyCode keyCode) 
    {
        this.keyCode = keyCode;
        keyCodeTmp.text = keyCode.ToString();
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }

        InputManager.Instance.AddKeyCode(keyCode);
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpwan.transform);
        noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInput(bool isApple)
    {

        //노트 삭제
        if (noteList.Count > 0)
        {
            Note delNote = noteList[0];
            delNote.DeleteNote();
            noteList.RemoveAt(0);
        }

        //사과 애니메이션
        if (isApple) {
        GameObject Newap = Instantiate(ap);
        Newap.transform.SetParent(noteSpwan.transform);
        Newap.transform.localPosition = new Vector3(0f, 40.1f, 0f);
        Destroy(Newap,0.4f);
        }
        else
        {
            GameObject Newap2 = Instantiate(ap2);
            Newap2.transform.SetParent(noteSpwan.transform);
            Newap2.transform.localPosition = new Vector3(0f, 40.1f, 0f);
            Destroy(Newap2, 0.4f);

        }

        //줄 내려오기
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //생성
        CreateNote(isApple);

        //노트 애니메이션
            anim.Play();
            btnSpriteRenderer.sprite = selectBtnSprite;

    }
    

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
