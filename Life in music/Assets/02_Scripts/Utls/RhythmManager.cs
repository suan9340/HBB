using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class RhythmManager : MonoSingleTon<RhythmManager>
{
    private Vector3 pos;
    //public float gap = 1;
    public AudioSource audioSource;

    public RhythmData.MyData data;
    private RhythmData.MyData loadData;
    private CurrnetstageSO currentStage;


    [Space(20)]
    [Header("Current Rhythm")]
    public GameObject curRhy;


    [Space(20)]
    [Header("--- RhythmNodeList ---")]

    private int currentIndex = 0;

    private float currentTime = 0f;
    private float beatPerSec = 0;

    private bool isRhythm = false;

    private void Start()
    {
        if (currentStage == null)
        {
            currentStage = Resources.Load<CurrnetstageSO>("SO/CurrentstageSO");
        }
    }

    private void Update()
    {
        if (isRhythm == false)
        {
            return;
        }
        else
        {
            CheckNoteANDInstantiate();
        }

    }

    private void CheckNoteANDInstantiate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60f / (data.Bpm * data.BestPerSec))
        {

            Debug.Log($"{currentIndex}  /  {data.NoteList.Count}");


            if (currentIndex >= data.NoteList.Count)
            {
                StopRhythmY();
                return;
            }
            else
            {
                var listBool = data.NoteList[currentIndex];
                EventManager<List<bool>>.TriggerEvent(ConstantManager.BEAT, listBool.beatFlag);
                currentIndex++;
                currentTime -= 60f / (data.Bpm * data.BestPerSec);
            }
        }
    }

    public void OnClickStopRhythm()
    {
        if (GameManager.Instance.gameState == DefineManager.GameState.CantClick) return;

        GameManager.Instance.SettingGameState(DefineManager.GameState.CantClick);
        SoundManager.Instance.StopLoopSource();

        StopRhythmSetting();
        NoteManager.Instance.RemoveNote();
        Debug.Log("STOP!!!!!!");
        isRhythm = false;

        StartCoroutine(GoHomeClose());
    }

    public void StopRhythmY()
    {
        data.isClear = true;
        StopRhythmSetting();
        NoteManager.Instance.RemoveNote();
        Debug.Log("ENd!!!!!!");
        SoundManager.Instance.StopLoopSource();
        isRhythm = false;

        StartCoroutine(GoHomeYPlayMusic());
    }

    public bool CheckTuto(string _name)
    {
        loadData = RhythmData.LoadData(_name);
        if (loadData == null)
        {
            Debug.Log($"Cant Load {_name}");
            return false;
        }

        if (loadData.isTuto)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void TutoClear()
    {
        loadData.isTuto = true;
    }

    public void ReadyRhythm(string _name)
    {
        //data = RhythmData.LoadData(_name);
        data = loadData;

        beatPerSec = 1f / data.BestPerSec;
        audioSource.clip = data.AudioClip;

        Invoke(nameof(StartRhythmGame), 1.5f);
    }


    public void StartRhythmGame()
    {
        isRhythm = true;
    }

    public void StopRhythmSetting()
    {
        Destroy(curRhy.gameObject);

        isRhythm = false;
        currentIndex = 0;
        audioSource.clip = null;
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void SettingCurRhythm(GameObject _obj)
    {
        curRhy = _obj;
    }

    private IEnumerator GoHomeYPlayMusic()
    {
        yield return new WaitForSeconds(3f);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        SoundManager.Instance.CheckYOnAudio(currentStage.clip);

        EventManager.TriggerEvent(ConstantManager.COIN_UI);
        EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM_PANEL);

        ChatMaanger.Instance.Text();
        SoundManager.Instance.PlayLoopSource(1f);
        yield break;
    }

    private IEnumerator GoHomeClose()
    {
        yield return new WaitForSeconds(3f);

        GameManager.Instance.SettingGameState(DefineManager.GameState.Playing);

        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);

        EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM_PANEL);

        TutoManager.Instance.SetActiveFalseText();
        SoundManager.Instance.PlayLoopSource(1f);
        yield break;
    }
}