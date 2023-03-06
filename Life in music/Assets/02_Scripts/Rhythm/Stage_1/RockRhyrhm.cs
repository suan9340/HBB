using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRhyrhm : RhythmBaseNote, IRhythmMom
{

    [Space(20)]
    [Header("--- RockNoteList ---")]
    public List<GameObject> rocknoteObj = new List<GameObject>();

    protected override void Start()
    {
        base.Start();

        NoteGen.Instance.IgenRock();

        EventManager<GameObject>.StartListening(ConstantManager.ROCK_ADD, AddNoteList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_Rock);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpRockFish();
        }
    }

    private void CheckType()
    {

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

    public void AddNoteList(GameObject _obj)
    {
        rocknoteObj.Add(_obj);
    }
}
