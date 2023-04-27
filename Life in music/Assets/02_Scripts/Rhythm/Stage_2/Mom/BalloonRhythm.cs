using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenBalloon();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.BALLOON_ADD, AddNoteList);
        CheckingTuto();

        EventManager<bool>.TriggerEvent(ConstantManager.RHYTHM_CHANGE_UI, true);
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
        if (noteObjList.Count == 4)
        {
            EventManager<bool>.TriggerEvent(ConstantManager.RHYTHM_CHANGE_UI, false);
        }
        else
        {
            EventManager<bool>.TriggerEvent(ConstantManager.RHYTHM_CHANGE_UI, true);
        }
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
                mySource.PlayOneShot(myClip);
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;

            default:
                isTuto = false;
                StartRhythm();
                break;
        }
    }


}
