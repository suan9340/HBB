using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageClearCheckSo", menuName = "ScriptableObject/StageClear")]
public class StageClearCheck : ScriptableObject
{
    public List<STAGECHECK> stageCheckList = new List<STAGECHECK>();
}

[Serializable]
public class STAGECHECK
{
    public bool stage = false;
}
