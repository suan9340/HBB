using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;
using System;


public class StarFishRhythm : MonoBehaviour, IRhythmMom
{
    [Space(20)]
    [Header("--- StarFishNoteList ---")]
    public List<GameObject> starfishNoteObj = new List<GameObject>();


    private void Awake()
    {
        NoteGen.Instance.IGenStarFish();
    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.STARFISH_ADD, AddNoteList);
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_STARFISH);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpShellfish();
        }
    }

    public void SetUpShellfish()
    {
        var _cnt = starfishNoteObj.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }


        var _shellonjSelect = _cnt - 1;
        var _obj = starfishNoteObj[_shellonjSelect].gameObject;

        _obj.GetComponent<StarFishMove>().ShellfishDown();
        starfishNoteObj.Remove(_obj);

    }

    public void AddNoteList(GameObject _obj)
    {
        starfishNoteObj.Add(_obj);
    }

}
