using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    public GameObject conchMOM = null;

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

    protected override void Update()
    {
        base.Update();
    }

    protected override void Tutoing()
    {
        Tuto();
    }


    protected override void RhythmGaming()
    {
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);

        if (GameManager.Instance.canClick)
        {
            GameManager.Instance.canClick = false;
            SetupConch();
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
        noteObjList.Add(_obj);
    }

    private void SetupConch()
    {
        var _cnt = noteObjList.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _conchOnjSelect = _cnt - 1;
        var _obj = noteObjList[_conchOnjSelect].gameObject;

        _obj.GetComponent<ConchMove>().ConchDown();

        noteObjList.Remove(_obj);


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
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                mySource.PlayOneShot(myClip);
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;

            default:
                isTuto = false;
                tutoObj[1].SetActive(false);
                StartRhythm();
                break;
        }
    }
}
