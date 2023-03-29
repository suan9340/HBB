using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeedRhythm : TutoMOM, IRhythmMom
{

    [Space(20)]
    [Header("--- SeaWweedNote List ---")]
    public List<GameObject> seaWeednoteObj = new List<GameObject>();


    [Space(20)]
    public GameObject seaWeedMOM = null;


    [Space(40)]
    [Header("------------------------")]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();

    private int tutoNum = 0;
    private bool isTuto = false;


    private void Awake()
    {
        NoteGen.Instance.IgenSeaweed();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.SEAWEED_ADD, AddNoteList);

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
                SetUpSeaweed();

                EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
            }
        }
    }

    private void StartRhythm()
    {
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SEAWEED);
        Invoke(nameof(SetUpSeaweedMOM), 1.5f);
    }

    public void SetUpSeaweed()
    {
        var _cnt = seaWeednoteObj.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }


        var _shellonjSelect = _cnt - 1;
        var _obj = seaWeednoteObj[_shellonjSelect].gameObject;

        // _obj.GetComponent<SeaWeedMove>().ShellfishDown();
        _obj.GetComponent<SeaWeedMove>().SeaweedUp();
        seaWeednoteObj.Remove(_obj);

    }

    public void AddNoteList(GameObject _obj)
    {
        seaWeednoteObj.Add(_obj);
    }

    private void SetUpSeaweedMOM()
    {
        if (seaWeedMOM == null)
        {
            Debug.LogError("seaWeedMOM is NULL!!!");
            return;
        }

        seaWeedMOM.SetActive(true);
    }


    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
                tutoObj[0].SetActive(true);
                tutoObj[1].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[0]);
                break;

            case 2:
                TutoManager.Instance.TextingOut(tutoTxt[1]);
                break;


            case 3:
                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
                tutoObj[1].SetActive(false);
                tutoObj[2].SetActive(true);
                mySource.PlayOneShot(myClip);
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;

            default:
                isTuto = false;
                tutoObj[0].SetActive(false);
                tutoObj[2].SetActive(false);
                StartRhythm();
                break;
        }
    }
}
