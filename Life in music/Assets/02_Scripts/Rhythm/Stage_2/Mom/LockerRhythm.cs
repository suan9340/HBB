using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenBook();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.LOCKER_ADD, AddNoteList);

        CheckingTuto();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void RhythmGaming()
    {
        SetupLocker();
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
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_LOCKER);
    }

    private void CheckingTuto()
    {
        var _isTutoGo = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE02_LOCKER);
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

    public void SetupLocker()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }
        UIManager.Instance.RhythmNoteEffect();
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        var _lockerSelect = _cnt - 1;
        var _obj = noteObjList[_lockerSelect].gameObject;

        _obj.GetComponent<LockerMove>().LockerUP();
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
