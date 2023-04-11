using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenWater();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.WATER_ADD, AddNoteList);
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }
}
