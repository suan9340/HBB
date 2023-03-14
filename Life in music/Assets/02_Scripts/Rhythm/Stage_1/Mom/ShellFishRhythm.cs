using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;
using System;

public class ShellFishRhythm : MonoBehaviour, IRhythmMom
{
    [Space(20)]
    [Header("--- ShellfishNote List ---")]
    public List<GameObject> shellfishnoteObj = new List<GameObject>();


    private void Awake()
    {
        NoteGen.Instance.IgenShell();
    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddNoteList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);
    }

    //private void Start()
    //{
    //    EventManager<GameObject>.StartListening(ConstantManager.SHELLFISHLIST_ADD, AddNoteList);

    //    RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SHELLFISH);

    //}
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpShellfish();
        }
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

    public void AddNoteList(GameObject _obj)
    {
        shellfishnoteObj.Add(_obj);
    }
}
