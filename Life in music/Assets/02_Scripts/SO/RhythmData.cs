using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RhythmData : ScriptableObject
{
    // ?ÅÏàò ?†Ïñ∏
    public const int BeatPerSec = 4; 

    
    [Serializable]
    public class BeatOnOff
    {
        public List<bool> beatFlag = new();

        public void Add(bool onOff)
        {
            beatFlag.Add(onOff);
        }

        public bool this[int index]
        {
            get => beatFlag[index];
            set => beatFlag[index] = value;
        }
    }

    [Serializable]
    public class MyData
    {
        public string name;
        public AudioClip AudioClip;
        public int Bpm = 60;
        public int BeatCount = 4;

        public List<BeatOnOff> NoteList = new();
    }

    public MyData data;


    public static MyData LoadData(string fileName)
    {
        var rhythmData = Resources.Load<RhythmData>(fileName);
        if (rhythmData == null)
        {
            Debug.LogError($"Missing data : {fileName}");
            return null;
        }
       
        return rhythmData.data;
    }
    
    
#if UNITY_EDITOR
    public static void CreateAssetData(string assetPathName, MyData myData)
    {
        var instance = CreateInstance<RhythmData>();

        instance.data = myData;

        AssetDatabase.CreateAsset(instance, assetPathName);
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(instance));
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
    }
#endif
}