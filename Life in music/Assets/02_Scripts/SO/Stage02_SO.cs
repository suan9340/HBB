using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Stage1RhythmSO", menuName = "ScriptableObject/Stage2RhythmSO")]

public class Stage02_SO : ScriptableObject
{
    public List<Info2> infos = new List<Info2>();
}


[Serializable]
public class Info2
{
    public DefineManager.Stage_01_Inst stage1;
    public GameObject stageRhythm;
}

