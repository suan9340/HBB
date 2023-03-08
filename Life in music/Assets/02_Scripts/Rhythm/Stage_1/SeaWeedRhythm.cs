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
        base.Start(); // RhythmBaseNote Start �Լ� ȣ��

        NoteGen.Instance.IgenSeaweed(); // 

        EventManager<GameObject>.StartListening(ConstantManager.SO_STAGE01_SEAWEED, AddNoteList);
        // �̺�Ʈ �Ŵ��� 

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_SEAWEED);
        // ���� �Ŵ��� 
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
        var _cnt = seaWeednoteObj.Count; // _cnt�� seaWeednoteObj ����Ʈ�� ������ �־��ش�.

        if (_cnt == 0) // ����Ʈ �� ������ 0�̶��?
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
