using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    [Header("--- ConchNote List ---")]
    public List<GameObject> conchNoteObj = new List<GameObject>();

    [Space(20)]
    public GameObject conchMOM = null;


    [Space(40)]
    [Header("------------------------")]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();

    private int tutoNum = 0;
    private bool isTuto = false;


    private void Awake()
    {
        NoteGen.Instance.IgenConch();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.CONCHLIST_ADD, AddNoteList);

        CheckingTuto();
    }

    private void Update()
    {
        InputKey();
    }
    
    private void InputKey()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.gameState != DefineManager.GameState.CantClick)
        {
            if (isTuto)
            {
                Tuto();
            }
            else
            {
                SetupConch();

                EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
            }
        }
    }

    private void CheckingTuto()
    {
        var _isTutoGO = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE01_CONCH);
        if (_isTutoGO)
        {
            Invoke(nameof(Tuto), 1.5f);
        }
        else
        {
            isTuto = false;
            StartRhythm();
        }
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_CONCH);
        Invoke(nameof(ConchStart), 1.5f);
    }


    public void AddNoteList(GameObject _obj)
    {
        conchNoteObj.Add(_obj);
    }

    private void SetupConch()
    {
        var _cnt = conchNoteObj.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _conchOnjSelect = _cnt - 1;
        var _obj = conchNoteObj[_conchOnjSelect].gameObject;

        _obj.GetComponent<ConchMove>().ConchDown();

        conchNoteObj.Remove(_obj);


        //   Debug.Log(_cnt);
    }

    private void ConchStart()
    {
        if (conchMOM == null)
        {
            Debug.LogError("ConchMom is NULL !!!!!!");
            return;
        }

        conchMOM.SetActive(true);

    }


    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
                tutoObj[0].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[0]);

                break;

            case 2:
                TutoManager.Instance.TextingOut(tutoTxt[1]);
                break;


            case 3:
                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;


            case 5:
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                mySource.PlayOneShot(myClip);
                TutoManager.Instance.TextingOut(tutoTxt[4]);
                break;



            default:
                isTuto = false;
                tutoObj[1].SetActive(false);
                StartRhythm();
                break;
        }
    }
}
