using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using DG.Tweening.Plugins;
using Unity.VisualScripting;

public class RhythmMaker : EditorWindow
{
    private string curName;
    private int curBpm;
    private int curNote = 4;
    private int curNoteBestPerSec = 3;
    private string curLoadName;

    [MenuItem("RhythmMaker/Rhythm maker")]

    public static void Open()
    {
        var win = GetWindow<RhythmMaker>("Rhythm Maker windows");
        win._Init();
        win._Load();
    }

    private void _Init()
    {
        Debug.Log("������??");
    }

    private void _Load()
    {
        Debug.Log("�ε���");
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        LeftMenus();
        RightMenus();


        EditorGUILayout.EndHorizontal();
    }


    private readonly string[] _bpmList =
    {
        "60","90", "100","110","120","140"
    };

    private readonly int[] _bpmIndexList =
    {
        0, 1, 2, 3, 4, 5
    };




    private readonly string[] _noteCountList =
    {
        "1", "2", "3", "4"
    };

    private readonly int[] _noteCountIndexList =
    {
        1, 2, 3, 4
    };

    private readonly string[] _noteBestPerSecList =
    {
        "1", "2", "3", "4", "5", "6"
    };

    private readonly int[] _noteBestPerSecIndexList =
    {
        1, 2, 3, 4, 5, 6
    };

    private const int musicPlayTimeSec = 60;

    private void LeftMenus()
    {
        EditorGUILayout.BeginVertical();
        {
            GUILayout.Box("Settings", GUILayout.ExpandWidth(true));


            // Name
            EditorGUI.BeginChangeCheck();
            curName = EditorGUILayout.TextField("Name", curName);

            if (EditorGUI.EndChangeCheck())
            {
                myData.name = curName;
                CalculateNoteCount();
            }



            // Audio clip
            EditorGUI.BeginChangeCheck();
            myData.AudioClip =
                EditorGUILayout.ObjectField("Audio clip", myData.AudioClip, typeof(AudioClip), false) as AudioClip;
            if (EditorGUI.EndChangeCheck())
            {
                CalculateNoteCount();
            }



            // Bpm
            EditorGUI.BeginChangeCheck();
            curBpm = EditorGUILayout.IntPopup("BPM", curBpm, _bpmList, _bpmIndexList);
            if (EditorGUI.EndChangeCheck())
            {
                if (int.TryParse(_bpmList[curBpm], out var value))
                {
                    myData.Bpm = value;
                    Debug.Log($"BPM : {_bpmList[curBpm]}");
                }

                CalculateNoteCount();
            }




            // Note count
            EditorGUI.BeginChangeCheck();
            curNote = EditorGUILayout.IntPopup("Note Transform Count", curNote, _noteCountList, _noteCountIndexList);
            if (EditorGUI.EndChangeCheck())
            {
                myData.BeatTrnCount = curNote;
                Debug.Log($"curNote: {curNote.ToString()}");
                CalculateNoteCount();
            }


            // Note BestPerSec
            EditorGUI.BeginChangeCheck();
            curNoteBestPerSec =
                EditorGUILayout.IntPopup("Note Best Per Sec", curNoteBestPerSec, _noteBestPerSecList, _noteBestPerSecIndexList);
            if (EditorGUI.EndChangeCheck())
            {
                myData.BestPerSec = curNoteBestPerSec;
                CalculateNoteCount();
            }


            // Save 
            if (GUILayout.Button("Save"))
            {
                if (curName == null)
                {
                    Debug.LogError($"curName is null!!!");
                    return;
                }
                RhythmData.CreateAssetData(curName + ".asset", myData);
            }


            // Load Name
            curLoadName = EditorGUILayout.TextField("LoadName", curLoadName);



            // Load
            if (GUILayout.Button("Load"))
            {
                if (curLoadName == null)
                {
                    Debug.LogError("curLoadName is null!!!");
                    return;
                }

                myData = RhythmData.LoadData(curLoadName);
                curName = curLoadName;
            }



        }
        EditorGUILayout.EndVertical();
    }


    private void CalculateNoteCount()
    {
        float beatCount = myData.Bpm / 60f * myData.BestPerSec;

        var noteCount = Mathf.RoundToInt(musicPlayTimeSec * beatCount);

        myData.NoteList = new();
        for (int i = 0; i < noteCount; i++)
        {
            var beatList = new RhythmData.BeatOnOff();
            for (int j = 0; j < myData.BeatTrnCount; j++)
            {
                beatList.Add(false);
            }

            myData.NoteList.Add(beatList);
        }
    }


    private Vector2 scrollPos;

    private void RightMenus()
    {
        EditorGUILayout.BeginVertical();

        GUILayout.Box("Notes", GUILayout.ExpandWidth(true));

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true);

        DrawNote();

        EditorGUILayout.EndScrollView();


        EditorGUILayout.EndVertical();
    }

    private void DrawNote()
    {
        if (myData == null) return;

        for (int i = 0; i < myData.NoteList.Count; i++)
        {
            DrawToggle(myData.NoteList[i]);

            if (i % myData.BestPerSec == myData.BestPerSec - 1)
            {
                GUILayout.Box("--------");
            }
        }
    }

    private void DrawToggle(RhythmData.BeatOnOff beat)
    {
        EditorGUILayout.BeginHorizontal();

        for (int i = 0; i < curNote; i++)
        {
            beat[i] = EditorGUILayout.Toggle(beat[i], GUILayout.MaxWidth(20));
        }

        EditorGUILayout.EndHorizontal();
    }

    public RhythmData.MyData myData = new();
}