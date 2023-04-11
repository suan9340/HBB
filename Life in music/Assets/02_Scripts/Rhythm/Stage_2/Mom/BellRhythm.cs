using System.Collections;
using System.Collections.Generic;
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
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void RhythmGaming()
    {
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }

    protected override void Tutoing()
    {


    }
    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_BELL);
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
