using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchRhythm : MonoBehaviour, IRhythmMom
{

    [Space(20)]
    [Header("--- ConchNote List ---")]
    public List<GameObject> conchNoteObj = new List<GameObject>();

    private void Awake()
    {
        NoteGen.Instance.IgenConch();
    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.CONCHLIST_ADD, AddNoteList);

        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_CONCH);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }

    public void AddNoteList(GameObject _obj)
    {

    }
}
