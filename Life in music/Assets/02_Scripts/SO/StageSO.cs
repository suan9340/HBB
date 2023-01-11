using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageSo", menuName = "ScriptableObject/StageSO")]
public class StageSO : ScriptableObject
{
    public List<StageInfo> stages = new List<StageInfo>();
}

[System.Serializable]
public class StageInfo
{
    [Header("StageName")]
    public DefineManager.StageNames stageNames;

    [Space(10)]
    [Header("Stage Instruments Count")]
    public int instrument = 0;

    [Header("Number of Instruments found by Users")]
    public int currentFindInstrament = 0;
}
