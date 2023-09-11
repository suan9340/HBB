using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassRhythm : TutoMOM, IRhythmMom
{
    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

}
