using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockRhyrhm : TutoMOM, IRhythmMom
{
    [Space(20)]
    [Header("--- Crab ---")]
    public GameObject crab = null;
    public List<Sprite> crabSprite = new List<Sprite>();
    private bool isMoving = false;

    private readonly WaitForSeconds crabSec = new WaitForSeconds(0.5f);
    private SpriteRenderer crabSpriteCom = null;
    private void Awake()
    {
        NoteGen.Instance.IgenRock();
    }

    protected override void Start()
    {
        base.Start();
        EventManager<GameObject>.StartListening(ConstantManager.ROCK_ADD, AddNoteList);

        if (crab != null)
        {
            crabSpriteCom = crab.GetComponent<SpriteRenderer>();
        }
        CHeckingTuto();
    }

    private void OnDisable()
    {
        EventManager<GameObject>.StopListening(ConstantManager.ROCK_ADD, AddNoteList);
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
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);

        if (GameManager.Instance.canClick)
        {
            GameManager.Instance.canClick = false;
            SetUpRockFish();
            StartCoroutine(CrabMove());

        }
    }


    private void CHeckingTuto()
    {
        var _isTutoGO = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE01_Rock);
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
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_Rock);
        Invoke(nameof(SetUpCrab), 1.5f);
    }
    public void SetUpRockFish()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _rockSelect = _cnt - 1;
        var _obj = noteObjList[_rockSelect].gameObject;

        noteObjList.Remove(_obj);


        _obj.GetComponent<RockMove>().CheckType();

    }

    public IEnumerator CrabMove()
    {
        if (isMoving)
        {
            yield return null;
        }

        isMoving = true;

        crabSpriteCom.sprite = crabSprite[0];
        yield return crabSec;
        crabSpriteCom.sprite = crabSprite[1];

        isMoving = false;
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

    private void SetUpCrab()
    {
        if (crab == null)
        {
            Debug.LogError("rockMOM is NULL!!!!");
            return;
        }
        crab.gameObject.SetActive(true);
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

            case 5:
                tutoObj[1].SetActive(false);
                tutoObj[2].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[4]);
                break;

            case 6:
                tutoObj[2].SetActive(false);
                tutoObj[3].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[5]);
                break;

            default:
                tutoObj[3].SetActive(false);

                isTuto = false;
                StartRhythm();
                break;
        }
    }
}
