using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Stage3RhythmSO", menuName = "ScriptableObject/STAGE/Stage3RhythmSO")]


public class Stage03_SO : ScriptableObject
{
    public List<Info3> infos = new List<Info3>();
}

[Serializable]
public class Info3
{
    public DefineManager.Stage_03_Band stage3;
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

