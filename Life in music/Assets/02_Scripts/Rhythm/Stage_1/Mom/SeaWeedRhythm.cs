using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeedRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    public GameObject seaWeedMOM = null;

    private void Awake()
    {
        NoteGen.Instance.IgenSeaweed();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.SEAWEED_ADD, AddNoteList);
        CheckingTuto();
        
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Tutoing()
    {
        Tuto();
    }


    protected override void RhythmGaming()
    {
        SetUpSeaweed();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }
  
    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SEAWEED);
        Invoke(nameof(SetUpSeaweedMOM), 1.5f);
    }

    private void CheckingTuto()
    {
        var _isTutoGo = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE01_SEAWEED);

        if (_isTutoGo)
        {
            Invoke(nameof(Tuto), 1.5f);
        }
        else
        {
            isTuto = false;
            StartRhythm();
        }
    }

    public void SetUpSeaweed()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        var _shellonjSelect = _cnt - 1;
        var _obj = noteObjList[_shellonjSelect].gameObject;

        // _obj.GetComponent<SeaWeedMove>().ShellfishDown();
        _obj.GetComponent<SeaWeedMove>().SeaweedUp();
        noteObjList.Remove(_obj);

    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
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
