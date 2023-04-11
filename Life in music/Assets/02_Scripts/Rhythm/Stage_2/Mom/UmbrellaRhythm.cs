using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenUmbrella();
    }
    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.UMBRELLA_ADD, AddNoteList);
    }


    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }
}
