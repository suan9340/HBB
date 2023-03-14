using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Stage1RhythmSO", menuName = "ScriptableObject/Stage1RhythmSO")]
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

    public List<string> chat = new List<string>();
}
