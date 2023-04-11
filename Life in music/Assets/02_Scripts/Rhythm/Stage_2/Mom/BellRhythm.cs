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

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }
}
