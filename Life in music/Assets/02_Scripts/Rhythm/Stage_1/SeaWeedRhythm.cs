using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeedRhythm : RhythmBaseNote, IRhythmMom
{

    [Space(20)]
    [Header("--- SeaWweedNote List ---")]
    public List<GameObject> seaWeednoteObj = new List<GameObject>();


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

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SEAWEED);

        Invoke(nameof(SetUpSeaweedMOM), 1.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpSeaweed();
        }
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
}
