using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Stage2RhythmSO", menuName = "ScriptableObject/STAGE/Stage2RhythmSO")]

public class Stage02_SO : ScriptableObject
{
    public List<Info2> infos = new List<Info2>();
}


[Serializable]
public class Info2
{
    public DefineManager.Stage_02_School stage2;
    public GameObject stageRhythm;
    public AudioClip clip;

    [Space(10)]
    [Header("--- NoteUI ---")]
    public GameObject noteObj;
    public GameObject noteEndObj;


    [Space(10)]
    [Header("--- Chat ---")]
    public List<string> chat = new List<string>();
}

