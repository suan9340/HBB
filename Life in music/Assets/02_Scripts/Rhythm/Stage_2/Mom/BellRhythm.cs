using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class BellRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenBell();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.BELL_ADD, AddNoteList);

        CheckingTuto();
        EventManager<bool>.TriggerEvent(ConstantManager.RHYTHM_CHANGE_UI, true);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void RhythmGaming()
    {
        SetUpBell();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }

    protected override void Tutoing()
    {
        Tuto();
    }


    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);

        if (noteObjList.Count == 3)
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
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_BELL);
    }

    private void CheckingTuto()
    {
        var _isTutoGo = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE02_BELL);
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

    public void SetUpBell()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }
        UIManager.Instance.RhythmNoteEffect();
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        var _bellSelect = _cnt - 1;
        var _obj = noteObjList[_bellSelect].gameObject;

        _obj.GetComponent<BellMove>().BellUp();
        noteObjList.Remove(_obj);
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
