using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRhythm : TutoMOM, IRhythmMom
{
    private void Awake()
    {
        NoteGen.Instance.IGenBook();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.BOOK_ADD, AddNoteList);
    }


    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }
}
