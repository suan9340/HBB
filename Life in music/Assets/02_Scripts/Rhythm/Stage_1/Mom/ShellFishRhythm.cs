using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class ShellFishRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    [Header("--- ShellfishNote List ---")]
    public List<GameObject> shellfishnoteObj = new List<GameObject>();


    [Space(20)]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();

    private int tutoNum = 0;
    private bool isTuto = false;
    private void Awake()
    {
        NoteGen.Instance.IgenShell();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddNoteList);

        Invoke(nameof(Tuto), 1.5f);
    }

    //private void Start()
    //{
    //    EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddNoteList);

    //    RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);

    //}
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.gameState != DefineManager.GameState.CantClick)
        {
            if (isTuto)
            {
                Tuto();

            }
            else
            {
                SetUpShellfish();
                EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
            }
        }
    }

    private void StartRhythm()
    {
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);
    }
    public void SetUpShellfish()
    {
        var _cnt = shellfishnoteObj.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        var _shellonjSelect = _cnt - 1;
        var _obj = shellfishnoteObj[_shellonjSelect].gameObject;

        _obj.GetComponent<ShellfishMove>().ShellfishDown();
        shellfishnoteObj.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        shellfishnoteObj.Add(_obj);
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
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;


            case 5:
                TutoManager.Instance.TextingOut(tutoTxt[4]);
                break;


            default:
                isTuto = false;
                StartRhythm();
                break;
        }

    }
}
