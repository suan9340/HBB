using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/RhthmCheck", fileName = "RhythmCheck")]
public class RhythmCheck : ScriptableObject
{
    public List<CheckingRhythmjNote> checkingNote = new List<CheckingRhythmjNote>();
}

[Serializable]
public class CheckingRhythmjNote
{
    public string name;
    public int num;
}

