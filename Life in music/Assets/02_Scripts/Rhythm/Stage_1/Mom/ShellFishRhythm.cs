using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Unity.VisualScripting;

public class ShellFishRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IgenShell();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddNoteList);
        CheckingTuto();

        EventManager<bool>.TriggerEvent(ConstantManager.RHYTHM_CHANGE_UI, true);
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
        SetUpShellfish();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }


    private void CheckingTuto()
    {
        var _isTutoGO = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE01_SHELLFISH);
        if (_isTutoGO)
        {
            Invoke(nameof(Tutoing), 1.5f);
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
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);
    }
    public void SetUpShellfish()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _shellonjSelect = _cnt - 1;
        var _obj = noteObjList[_shellonjSelect].gameObject;

        _obj.GetComponent<ShellfishMove>().ShellfishDown();
        noteObjList.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
        CheckCanClickRhythm();
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
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[1]);
                break;


            case 3:
              
                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
                
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;


            default:
                isTuto = false;
                StartRhythm();
                break;
        }

    }
}
