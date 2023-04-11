using System.Collections;
using System.Collections.Generic;
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
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }
}
