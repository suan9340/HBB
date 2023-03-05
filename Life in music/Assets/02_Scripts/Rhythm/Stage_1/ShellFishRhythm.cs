using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;
using System;

public class ShellFishRhythm : RhythmMusicBase, IRhythmMom
{
    [Header("ShellfishNote List")]
    [Space(20)]
    public List<GameObject> shellfishnoteObj = new List<GameObject>();

    protected override void Start()
    {
        base.Start();

        EventManager.StartListening(ConstantManager.START_RHYTHM, StartShellFishMusic);
        EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddShellFishList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnCLickShellScreen();
        }
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

    public void AddShellFishList(GameObject _obj)
    {
        shellfishnoteObj.Add(_obj);
    }
}
