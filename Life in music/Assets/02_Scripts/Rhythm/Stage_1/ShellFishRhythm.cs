using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;
using System;

public class ShellFishRhythm : RhythmMusicBase
{
    [Header("ShellfishNote List")]
    [Space(20)]
    public List<GameObject> shellfishnoteObj = new List<GameObject>();

    [Header("ShellfishNotePos List")]
    public List<GameObject> posList = new List<GameObject>();

    [Header("Note Obj")]
    public List<GameObject> noteObj = new List<GameObject>();

    protected override void Start()
    {
        base.Start();

        EventManager.StartListening(ConstantManager.START_RHYTHM, StartShellFishMusic);
        EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddShellFishList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);

        SettingRhythmPosition();
        SettingRhythmObjects();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnCLickShellScreen();
        }
    }

    private void SettingRhythmPosition()
    {
        RhythmManager.Instance.SettingRhythmPosition(posList[0]);
        RhythmManager.Instance.SettingRhythmPosition(posList[1]);
        RhythmManager.Instance.SettingRhythmPosition(posList[2]);
        RhythmManager.Instance.SettingRhythmPosition(posList[3]);
    }

    private void SettingRhythmObjects()
    {
        RhythmManager.Instance.SettingRhythmObject(noteObj[0]);
        RhythmManager.Instance.SettingRhythmObject(noteObj[1]);
        RhythmManager.Instance.SettingRhythmObject(noteObj[2]);
        RhythmManager.Instance.SettingRhythmObject(noteObj[3]);
        RhythmManager.Instance.SettingRhythmObject(noteObj[4]);
    }

    public void OnCLickShellScreen()
    {
        SetUpShellfish();
    }

    public void SetUpShellfish()
    {
        var _cnt = shellfishnoteObj.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }


        var _shellonjSelect = _cnt - 1;
        var _obj = shellfishnoteObj[_shellonjSelect].gameObject;

        _obj.GetComponent<ShellfishMove>().ShellfishDown();
        shellfishnoteObj.Remove(_obj);
    }

    public void StartShellFishMusic()
    {
        StartMusic();
    }

    public void AddShellFishList(GameObject _shell)
    {
        shellfishnoteObj.Add(_shell);
    }
}
