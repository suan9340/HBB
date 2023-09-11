using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoRhythm : TutoMOM, IRhythmMom
{
    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }
}
