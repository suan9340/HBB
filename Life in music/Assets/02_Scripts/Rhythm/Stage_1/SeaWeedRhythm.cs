using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class SeaWeedRhythm : RhythmBaseNote, IRhythmMom
{
    [Space(20)]
    [Header("--- SeaWweedNote List ---")]

    public List<GameObject> seaWeednoteObj = new List<GameObject>();


    protected override void Start()
    {
        base.Start(); // RhythmBaseNote Start 함수 호출

        NoteGen.Instance.IgenSeaweed(); // 

        EventManager<GameObject>.StartListening(ConstantManager.SO_STAGE01_SEAWEED, AddNoteList);
        // 이벤트 매니저 

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SEAWEED);
        // 리듬 매니저 
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
        var _cnt = seaWeednoteObj.Count; // _cnt에 seaWeednoteObj 리스트의 갯수를 넣어준다.

        if (_cnt == 0) // 리스트 안 갯수가 0이라면?
        {
            Debug.Log("List Count is Zerooo"); 
            return;
        }
        
        var _shellonjSelect = _cnt - 1; // 
        var _obj = seaWeednoteObj[_shellonjSelect].gameObject;

        _obj.GetComponent<ShellfishMove>().ShellfishDown();
        seaWeednoteObj.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        seaWeednoteObj.Add(_obj);
    }
}
