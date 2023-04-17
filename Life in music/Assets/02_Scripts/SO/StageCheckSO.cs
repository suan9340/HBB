using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "CheckSO", menuName = "ScriptableObject/STAGECheck/CheckClear")]
public class StageCheckSO : ScriptableObject
{
    public List<ClearObjInfo> cObject = new List<ClearObjInfo>();
}

[Serializable]
public class ClearObjInfo
{
    public string name;
    public bool isClear;
}

