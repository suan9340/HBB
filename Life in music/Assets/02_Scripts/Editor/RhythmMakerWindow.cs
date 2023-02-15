using UnityEditor;
using UnityEngine;

public class RhythmMaker : EditorWindow
{
    private int curBpm;
    private int curNote = 4;
    private string curName;



    [MenuItem("RhythmMaker/Rhythm maker")]

    public static void Open()
    {
        var win = GetWindow<RhythmMaker>("Rhythm Maker windows");
        win._Init();
        win._Load();
    }

    private void _Init()
    {
        Debug.Log("생성됨??");
    }

    private void _Load()
    {
        Debug.Log("로드중");
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
        "60", "100","110","120","140"
    };

    private readonly int[] _bpmIndexList =
    {
        0, 1, 2, 3, 4
    };




    private readonly string[] _noteCountList =
    {
        "1", "2", "3", "4"
    };

    private readonly int[] _noteCountIndexList =
    {
        1, 2, 3, 4
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
                Debug.Log($"curName: {myData.name}");
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
            curNote = EditorGUILayout.IntPopup("Note Count", curNote, _noteCountList, _noteCountIndexList);
            if (EditorGUI.EndChangeCheck())
            {
                myData.BeatCount = curNote;
                Debug.Log($"curNote: {curNote.ToString()}");
                CalculateNoteCount();
            }



            // Save and Load
            if (GUILayout.Button("Save"))
            {
                //RhythmData.CreateAssetData("Assets/Resources/SO/RhythmSO/data1.asset", myData);
                RhythmData.CreateAssetData("data1.asset", myData);
            }

            if (GUILayout.Button("Load"))
            {
                myData = RhythmData.LoadData("data1");
            }
        }
        EditorGUILayout.EndVertical();
    }


    private void CalculateNoteCount()
    {
        float beatCount = myData.Bpm / 60f * RhythmData.BeatPerSec;

        var noteCount = Mathf.RoundToInt(musicPlayTimeSec * beatCount);

        myData.NoteList = new();
        for (int i = 0; i < noteCount; i++)
        {
            var beatList = new RhythmData.BeatOnOff();
            for (int j = 0; j < myData.BeatCount; j++)
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

            if (i % RhythmData.BeatPerSec == RhythmData.BeatPerSec - 1)
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