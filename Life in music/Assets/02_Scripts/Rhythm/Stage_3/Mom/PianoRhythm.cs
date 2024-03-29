using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoRhythm : TutoMOM, IRhythmMom
{
    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.PIANO_ADD, AddNoteList);
        CheckingTuto();
    }


    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

    private void CheckingTuto()
    {
        var _isTutoGo = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE03_PIANO);

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

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE03_PIANO);
    }

    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
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
                isTuto = false;
                StartRhythm();
                break;
        }
    }
}
