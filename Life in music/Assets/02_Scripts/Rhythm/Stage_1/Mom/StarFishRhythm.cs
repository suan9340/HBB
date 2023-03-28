using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarFishRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    [Header("--- StarFishNoteList ---")]
    public List<GameObject> starfishNoteObj = new List<GameObject>();

    [Space(20)]
    public GameObject starFIshImg = null;

    [Space(20)]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();

    private int tutoNum = 0;
    private bool isTuto = false;
    private void Awake()
    {
        NoteGen.Instance.IGenStarFish();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.STARFISH_ADD, AddNoteList);

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
                SetUpStarfish();

                EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
            }

        }
    }

    private void StartRhythm()
    {
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_STARFISH);
        Invoke(nameof(StarFishMOM), 1.5f);
    }

    public void SetUpStarfish()
    {
        var _cnt = starfishNoteObj.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        var _starfishonjSelect = _cnt - 1;
        var _obj = starfishNoteObj[_starfishonjSelect].gameObject;

        _obj.GetComponent<StarFishMove>().StarfishDown();
        starfishNoteObj.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        starfishNoteObj.Add(_obj);
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
                mySource.PlayOneShot(myClip);
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
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
