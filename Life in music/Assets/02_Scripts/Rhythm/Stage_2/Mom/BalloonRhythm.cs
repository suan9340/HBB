using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonRhythm : TutoMOM, IRhythmMom
{
    int num = 0;
    private void Awake()
    {
        NoteGen.Instance.IGenBalloon();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.BALLOON_ADD, AddNoteList);
        CheckingTuto();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void RhythmGaming()
    {
        SetupBalloon();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }

    protected override void Tutoing()
    {
        Tuto();
    }

  
    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_BALLOON);
    }

    private void SetupBalloon()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }
        UIManager.Instance.RhythmNoteEffect();
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        var _shellonjSelect = _cnt - 1;
        var _obj = noteObjList[_shellonjSelect].gameObject;

        _obj.GetComponent<BalloonMove>().BalloonUp();
        noteObjList.Remove(_obj);
    }

    private void CheckingTuto()
    {
        var _isTutoGo = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE02_BALLOON);

        if (_isTutoGo)
        {
            Invoke(nameof(Tuto), 1.5f);
        }
        else
        {
            isTuto = false;
            StartRhythm();
        }
    }

    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
                break;

            case 2:
                break;


            case 3:
                break;


            case 4:
                break;

            default:
                isTuto = false;
                StartRhythm();
                break;
        }
    }


}
