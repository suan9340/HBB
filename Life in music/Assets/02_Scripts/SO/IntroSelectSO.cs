using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/IntroSelectTextSO", fileName = "IntroSelectSO")]

public class IntroSelectSO : ScriptableObject
{
    public List<IntroTextInfo> textList = new List<IntroTextInfo>();
}

[Serializable]
public class IntroTextInfo
{
    public string num;
    public List<string> first = new List<string>();
    public List<string> second = new List<string>();
}