using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickInstruments : MonoBehaviour
{

    [Header("AudioSound")]
    public AudioSource effectAudio = null;
    public AudioClip clip = null;
    public GameObject instrumetnsObj = null;

    [Space(20)]
    public int num;
    public int plusNum = 0;

    [Space(20)]
    public ObjectClear objectClear = null;

    //public Canvas rhythmCanvas;

    Vector2 rayOrigin = Vector2.zero;
    RaycastHit2D hit;


    private void Start()
    {
        CheckAudioComponents();

        //CheckCurrnetClearState();
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.gameState == DefineManager.GameState.CantClick) return;

            rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnClickEvent();
                }
            }
        }
    }

    private void CheckAudioComponents()
    {
        if (effectAudio == null && clip != null)
        {
            var _effectobj = GameObject.Find("SoundManager");
            effectAudio = _effectobj.transform.GetChild(0)?.GetComponent<AudioSource>();
        }
        if (objectClear == null)
        {
            objectClear = GetComponent<ObjectClear>();
        }
    }

    private void CheckStage()
    {
        GameObject _instante = null;
        GameObject _loadObj = null;


        var _stage = GameManager.Instance.GetCurrentStage();

        switch (_stage)
        {
            case DefineManager.StageNames.Sea_01:
                Stage01_SO _so1 = Resources.Load<Stage01_SO>("SO/Stage/Stage1RhythmSO");

                _loadObj = _so1.infos[num].stageRhythm;

                InstantiateRhythm(_instante, _loadObj);
                ChatMaanger.Instance.SetChatting(_so1.infos[num].chat);
                GameManager.Instance.SetClip(_so1.infos[num].clip);

                NoteManager.Instance.SettingNoteObj(_so1.infos[num].noteObj);
                NoteManager.Instance.SettingCenterImage(_so1.infos[num].noteEndObj);

                break;



            case DefineManager.StageNames.School_02:
                Stage02_SO _so2 = Resources.Load<Stage02_SO>("SO/Stage/Stage2RhythmSO");
                _loadObj = _so2.infos[num].stageRhythm;

                InstantiateRhythm(_instante, _loadObj);
                ChatMaanger.Instance.SetChatting(_so2.infos[num].chat);

                GameManager.Instance.SetClip(_so2.infos[num].clip);

                NoteManager.Instance.SettingNoteObj(_so2.infos[num].noteObj);
                NoteManager.Instance.SettingCenterImage(_so2.infos[num].noteEndObj);
                break;



            case DefineManager.StageNames.PlayGround_03:


                break;



            case DefineManager.StageNames.Cafe_04:

                break;
        }
    }

    public void OnClickEvent()
    {
        if (GameManager.Instance.GetGameState() == DefineManager.GameState.Rhythm) return;

        RhythmManager.Instance.SetObjectClearObj(objectClear);

        if (objectClear.isCCC == true)
        {
            //Debug.Log("NONO");
            return;
        }

        LoadRhythmStart();

        //if (BoolCurrnetIsClear())
        //{
        //}
        //else
        //{
        //    return;
        //}

    }

    private void LoadRhythmStart()
    {
        effectAudio.PlayOneShot(clip);
        GameManager.Instance.SettingGameState(DefineManager.GameState.Rhythm);

        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM_PANEL);

        if (instrumetnsObj != null)
            instrumetnsObj.SetActive(true);

        CheckStage();
        SoundManager.Instance.StopLoopSource();
    }

    private void InstantiateRhythm(GameObject _instobj, GameObject _loadobj)
    {
        _instobj = Instantiate(_loadobj);
        //_instobj.transform.SetParent(rhythmCanvas.transform.GetChild(2), false);
        RhythmManager.Instance.SettingCurRhythm(_instobj);
    }
}
