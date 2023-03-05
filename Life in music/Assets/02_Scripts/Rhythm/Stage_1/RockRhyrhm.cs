using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRhyrhm : RhythmMusicBase, IRhythmMom
{

    [Header("RockNoteList")]
    [Space(20)]
    public List<GameObject> rocknoteObj = new List<GameObject>();

    protected override void Start()
    {
        base.Start();
    }

    public void AddShellFishList(GameObject _obj)
    {
        rocknoteObj.Add(_obj);
    }
}
