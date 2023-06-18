using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PuzzleStageEndSO", fileName = "PuzzleStageEndSO")]
public class PuzzleStageEndSO : ScriptableObject
{
    public List<Stages> stagesEndTxt = new List<Stages>();
}

[Serializable]
public class Stages
{
    public string stageName;
    public List<string> stageEndPuzzleList = new List<string>();
}


