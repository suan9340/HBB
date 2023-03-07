using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeedRhythm : RhythmBaseNote, IRhythmMom
{

    [Space(20)]
    [Header("--- SeaWweedNote List ---")]
    public List<GameObject> seaWeednoteObj = new List<GameObject>();


    protected override void Start()
    {
        base.Start();

        NoteGen.Instance.IgenSeaweed();
    }



    public void AddNoteList(GameObject _obj)
    {
        seaWeednoteObj.Add(_obj);
    }
}
