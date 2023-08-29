using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    #region SingleTon

    private static RhythmManager _instance = null;
    public static RhythmManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RhythmManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("RhythmManager").AddComponent<RhythmManager>();
                }
            }
            return _instance;
        }
    }

    #endregion
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


    [Space(20)]
    [Header("--- RhythmCheck ---")]
    public RhythmCheck RhythmCheckSO = null;


    [Space(20)]
    [Header("--- RhythmCheckClearObj ---")]
    public ObjectClear objClear = null;
    public Text perfectClearTxt = null;

    private int currentIndex = 0;

    private float currentTime = 0f;
    private float beatPerSec = 0;

    private bool isRhythm = false;
    public bool isPerfectClear = false;

    private void Start()
    {
        if (currentStage == null)
        {
            currentStage = Resources.Load<CurrnetstageSO>("SO/CurrentstageSO");
        }

        if (RhythmCheckSO == null)
        {
            RhythmCheckSO = Resources.Load<RhythmCheck>("SO/RhythmCheck");
        }

        ResetRhythmCheckSO();
    }

    private void Update()
    {
        if (isRhythm == false)
        {
            currentTime = 0;
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

            //Debug.Log($"{currentIndex}  /  {data.NoteList.Count}");


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
        CheckPerfect();
        StopRhythmSetting();
        NoteManager.Instance.RemoveNote();
        //Debug.Log("ENd!!!!!!");
        SoundManager.Instance.StopLoopSource();
        isRhythm = false;


        if (isPerfectClear)
        {
            StartCoroutine(PerFectCor());
        }
        else
        {
            StartCoroutine(GoHomeYPlayMusic());
        }
    }

    public bool CheckTuto(string _name)
    {
        SoundManager.Instance.BoggleSound(false);

        loadData = RhythmData.LoadData(_name);
        if (loadData == null)
        {
            Debug.LogError($"Cant Load {_name}");
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

    private void CheckPerfect()
    {
        var _a = RhythmCheckSO.checkingNote[0].num;
        var _b = RhythmCheckSO.checkingNote[1].num;
        var _c = RhythmCheckSO.checkingNote[2].num;

        //Debug.Log($"Perfect : {_a} / Good : {_b} / Bad : {_c}");

        if ((_b == 0) && (_c == 0))
        {
            isPerfectClear = true;
        }
        else
        {
            isPerfectClear = false;
        }
    }

    public void TutoClear()
    {
        loadData.isTuto = true;

        UIManager.Instance.JudgmentObj.SetActive(true);
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
        SoundManager.Instance.BoggleSound(true);
        Destroy(curRhy.gameObject);

        isRhythm = false;
        currentIndex = 0;
        audioSource.clip = null;

        ResetRhythmCheckSO();
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void SettingCurRhythm(GameObject _obj)
    {

        curRhy = _obj;
    }

    private IEnumerator PerFectCor()
    {
        perfectClearTxt.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        perfectClearTxt.gameObject.SetActive(false);

        yield return GoHomeYPlayMusic();
    }
    private IEnumerator GoHomeYPlayMusic()
    {
        yield return new WaitForSeconds(3f);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        SoundManager.Instance.CheckYOnAudio(currentStage.clip);

        EventManager.TriggerEvent(ConstantManager.COIN_UI);
        EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM_PANEL);

        //ChatMaanger.Instance.Text();
        ChatMaanger.Instance.FirstSetText();
        SoundManager.Instance.PlayLoopSource();

        yield return new WaitForSeconds(0.5f);

        objClear.CompleteRhythm();


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
        SoundManager.Instance.PlayLoopSource();
        yield break;
    }

    public void SetObjectClearObj(ObjectClear _objClear)
    {
        objClear = _objClear;
    }

    private void ResetRhythmCheckSO()
    {
        UIManager.Instance.JudgmentObj.SetActive(false);
        RhythmCheckSO.checkingNote[0].num = 0;
        RhythmCheckSO.checkingNote[1].num = 0;
        RhythmCheckSO.checkingNote[2].num = 0;
    }
}