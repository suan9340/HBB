using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    [Header("--- ConchNote List ---")]
    public List<GameObject> conchNoteObj = new List<GameObject>();

    [Space(20)]
    public GameObject conchMOM = null;


    [Space(40)]
    [Header("------------------------")]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();

    private int tutoNum = 0;
    private bool isTuto = false;


    private void Awake()
    {
        NoteGen.Instance.IgenConch();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.CONCHLIST_ADD, AddNoteList);

        Invoke(nameof(Tuto), 1.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTuto)
            {
                Tuto();
            }
            else
            {
                SetupConch();

                EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
            }
        }
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_CONCH);
        Invoke(nameof(ConchStart), 1.5f);
    }


    public void AddNoteList(GameObject _obj)
    {
        conchNoteObj.Add(_obj);
    }

    private void SetupConch()
    {
        var _cnt = conchNoteObj.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        var _conchOnjSelect = _cnt - 1;
        var _obj = conchNoteObj[_conchOnjSelect].gameObject;

        _obj.GetComponent<ConchMove>().ConchDown();

        conchNoteObj.Remove(_obj);


        //   Debug.Log(_cnt);
    }

    private void ConchStart()
    {
        if (conchMOM == null)
        {
            Debug.LogError("ConchMom is NULL !!!!!!");
            return;
        }

        conchMOM.SetActive(true);

    }


    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;

                break;

            case 2:

                break;

            default:
                isTuto = false;
                StartRhythm();
                break;
        }
    }
}
