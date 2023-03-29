using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Stage1RhythmSO", menuName = "ScriptableObject/STAGE/Stage1RhythmSO")]
public class Stage01_SO : ScriptableObject
{
    public List<Info1> infos = new List<Info1>();
}


[Serializable]
public class Info1
{
    public DefineManager.Stage_01_Inst stage1;
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
