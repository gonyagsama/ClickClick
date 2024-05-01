using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] AudioClip ac;
    [SerializeField] AudioClip ac2;
    [SerializeField] AudioSource acSource;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    private bool isGameClear = false;
    private bool isGameOver = false;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;
    [HideInInspector] public static float myTime;
    [HideInInspector] public static float minTime;
    public float currentTime;

    public bool IsGameClear()
    {
        return isGameClear;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameDone
    {
        get
        {

            if (isGameClear || isGameOver)
            {
                minTime = PlayerPrefs.GetFloat("minTime", 1000f);
                if (minTime >= myTime)
                {
                    minTime = myTime;
                    PlayerPrefs.SetFloat("minTime", minTime);
                }

                SceneManager.LoadScene("ClearScenes");
                return true;
            }

            else
            {
                return false;
            }
        }

    }
    public void CalculateScore(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            nextNoteGroupUnlockCnt++;
            acSource.PlayOneShot(ac);

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.instance.CreateNoteGroup();

            }

            if (maxScore <= score)
            {
                isGameClear = true;
            }
        }
        else
        {
            score--;
            acSource.PlayOneShot(ac2);
        }


        UiManager.instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        Debug.Log("Game Restart!... ... ...");
        SceneManager.LoadScene(0);
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

        acSource = GetComponent<AudioSource>();

    }

    IEnumerator TimerCoroutine()
    {
        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            myTime = currentTime;
            UiManager.instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        //GameOver
        isGameOver = true;
    }
}

