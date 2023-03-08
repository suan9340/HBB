using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockRhyrhm : RhythmBaseNote, IRhythmMom
{

    [Space(20)]
    [Header("--- RockNoteList ---")]
    public List<GameObject> rocknoteObj = new List<GameObject>();

    [Space(20)]
    [Header("--- Crab ---")]
    public Image crab = null;
    public List<Sprite> crabSprite = new List<Sprite>();
    private bool isMoving = false;


    private readonly WaitForSeconds crabSec = new WaitForSeconds(0.5f);
    private void Awake()
    {
        NoteGen.Instance.IgenRock();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.ROCK_ADD, AddNoteList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_Rock);

        Invoke(nameof(SetUpCrab), 1.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpRockFish();
            StartCoroutine(CrabMove());
        }
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
}
