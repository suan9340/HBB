using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchRhythm : MonoBehaviour, IRhythmMom
{
    [Space(20)]
    [Header("--- ConchNote List ---")]
    public List<GameObject> conchNoteObj = new List<GameObject>();

    [Space(20)]
    public GameObject conchMOM = null;


    private void Awake()
    {
        NoteGen.Instance.IgenConch();
    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.CONCHLIST_ADD, AddNoteList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_CONCH);


        Invoke(nameof(ConchStart), 1.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetupConch();
            EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
        }
    }

    public void AddNoteList(GameObject _obj)
    {
        conchNoteObj.Add(_obj);
    }

    private void SetupConch()
    {
        var _cnt = conchNoteObj.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        var _conchOnjSelect = _cnt - 1;
        var _obj = conchNoteObj[_conchOnjSelect].gameObject;

        _obj.GetComponent<ConchMove>().ConchDown();

        conchNoteObj.Remove(_obj);


     //   Debug.Log(_cnt);
    }

    private void ConchStart()
    {
        if (conchMOM == null)
        {
            Debug.LogError("ConchMom is NULL !!!!!!");
            return;
        }

        conchMOM.SetActive(true);

    }

}
