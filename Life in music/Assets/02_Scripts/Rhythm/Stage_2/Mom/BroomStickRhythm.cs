using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BroomStickRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenBroomStick();

    }
    protected override void Start()
    {
        base.Start();
        EventManager<GameObject>.StartListening(ConstantManager.BROOMSTICK_ADD, AddNoteList);
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
        SetupBroomStick();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }

    private void CheckingTuto()
    {
        var _isTutoGO = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE02_BROOMSTICK);
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
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_BROOMSTICK);
    }

    //´­·¶À»¶§
    public void SetupBroomStick()
    {
        var _cnt = noteObjList.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _BroomonjSelect = _cnt - 1;
        var _obj = noteObjList[_BroomonjSelect].gameObject;

        _obj.GetComponent<BroomStickMove>().BroomStickDown();
        noteObjList.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
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

            default:
                tutoObj[0].SetActive(false);
                isTuto = false;
                StartRhythm();
                break;
        }
    }
}