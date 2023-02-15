using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RhythmData : ScriptableObject
{
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
        var _saveName = LoadCombineString(fileName);
        var rhythmData = Resources.Load<RhythmData>(_saveName);
        if (rhythmData == null)
        {
            Debug.LogError($"Missing data : {_saveName}");
            return null;
        }

        Debug.Log($"Sucessful Load data: {_saveName}");
        return rhythmData.data;
    }


#if UNITY_EDITOR
    public static void CreateAssetData(string assetPathName, MyData myData)
    {
        var instance = CreateInstance<RhythmData>();
        var _saveName = CreateCombineString(assetPathName);

        instance.data = myData;

        AssetDatabase.CreateAsset(instance, _saveName);
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(instance));
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
    }
#endif

    private static string CreateCombineString(string _filename)
    {
        var _path = "Assets/Resources/SO/RhythmSO/";
        var _saveName = Path.Combine(_path, _filename);
        Debug.Log(_saveName);

        return _saveName;
    }

    private static string LoadCombineString(string _filename)
    {
        var _path = "SO/RHythmSO/";
        var _saveName = Path.Combine(_path, _filename);

        return _saveName;
    }
}