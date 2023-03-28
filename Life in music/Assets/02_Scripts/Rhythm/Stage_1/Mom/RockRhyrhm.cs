using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockRhyrhm : MonoBehaviour, IRhythmMom
{

    [Space(20)]
    [Header("--- RockNoteList ---")]
    public List<GameObject> rocknoteObj = new List<GameObject>();

    [Space(20)]
    [Header("--- Crab ---")]
    public Image crab = null;
    public List<Sprite> crabSprite = new List<Sprite>();
    private bool isMoving = false;


    [Space(20)]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();

    private int tutoNum = 0;
    private bool isTuto = false;

    private readonly WaitForSeconds crabSec = new WaitForSeconds(0.5f);
    private void Awake()
    {
        NoteGen.Instance.IgenRock();
    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.ROCK_ADD, AddNoteList);

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
                SetUpRockFish();

                StartCoroutine(CrabMove());
                EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
            }

        }
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_Rock);

        Invoke(nameof(SetUpCrab), 1.5f);
    }
    public void SetUpRockFish()
    {
        var _cnt = rocknoteObj.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }


        var _rockSelect = _cnt - 1;
        var _obj = rocknoteObj[_rockSelect].gameObject;

        rocknoteObj.Remove(_obj);


        _obj.GetComponent<RockMove>().CheckType();

    }

    public IEnumerator CrabMove()
    {
        if (isMoving)
        {
            yield return null;
        }

        isMoving = true;

        crab.sprite = crabSprite[0];
        yield return crabSec;
        crab.sprite = crabSprite[1];

        isMoving = false;
    }

    public void AddNoteList(GameObject _obj)
    {
        rocknoteObj.Add(_obj);
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
                tutoObj[0].SetActive(false);
                tutoObj[1].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
                tutoObj[1].SetActive(false);
                tutoObj[2].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;

            case 5:
                tutoObj[2].SetActive(false);
                tutoObj[3].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[4]);
                break;


            default:
                tutoObj[3].SetActive(false);
                TutoManager.Instance.SetActiveFalseText();
                isTuto = false;
                StartRhythm();
                break;
        }
    }
}
