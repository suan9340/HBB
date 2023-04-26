using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarFishRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    public GameObject starFIshImg = null;

    private void Awake()
    {
        NoteGen.Instance.IGenStarFish();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.STARFISH_ADD, AddNoteList);
        CheckingTuto();

        EventManager<bool>.TriggerEvent(ConstantManager.RHYTHM_CHANGE_UI, true);
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
        SetUpStarfish();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }


    private void CheckingTuto()
    {
        var _isTutoGO = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE01_STARFISH);
        if (_isTutoGO)
        {
            Invoke(nameof(Tuto), 1.5f);
        }
        else
        {
            isTuto = false;
            StartRhythm();
        }
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_STARFISH);
        Invoke(nameof(StarFishMOM), 1.5f);
    }

    public void SetUpStarfish()
    {
        var _cnt = noteObjList.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _starfishonjSelect = _cnt - 1;
        var _obj = noteObjList[_starfishonjSelect].gameObject;

        _obj.GetComponent<StarFishMove>().StarfishDown();
        noteObjList.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
        CheckCanClickRhythm();
    }

    private void StarFishMOM()
    {
        if (starFIshImg == null)
        {
            Debug.LogError("Starfish_Image is NULL!!!!");
            return;
        }

        starFIshImg.gameObject.SetActive(true);
    }

    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;


        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
                TutoManager.Instance.TextingOut(tutoTxt[0]);
                tutoObj[0].SetActive(true);
                break;


            case 2:
                TutoManager.Instance.TextingOut(tutoTxt[1]);
                break;


            case 3:

                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
                mySource.PlayOneShot(myClip);
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;


            default:
                isTuto = false;
                tutoObj[1].SetActive(false);
                StartRhythm();
                break;
        }
    }
}
