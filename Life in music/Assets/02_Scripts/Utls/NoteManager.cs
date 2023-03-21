using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoSingleTon<NoteManager>
{
    [Header("--- NoteTrnYObject ---")]
    public GameObject noteObj = null;
    public RectTransform noteTrn = null;


    [Space(20)]
    [Header("--- NoteList ---")]
    public List<GameObject> noteList = new List<GameObject>();

    private void Start()
    {
        EventManager.StartListening(ConstantManager.NOTE_IMAGE_INSTANCE, InstantiateNote);
        EventManager.StartListening(ConstantManager.NOTE_LIST_REMOVE, RemoveBackList);
    }

    public void SettingNoteObj(GameObject _obj)
    {
        noteObj = _obj;
    }

    public void InstantiateNote()
    {
        var _obj = Instantiate(noteObj, noteTrn);
        _obj.transform.SetParent(noteTrn.transform);
        _obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        noteList.Add(_obj);
    }

    private void RemoveList()
    {
        noteList.Clear();
    }

    private void RemoveBackList()
    {
        if (noteList.Count <= 0)
        {
            Debug.Log("NoteList is NULL!!!!!!!!!");
            return;
        }

        //var _noteCnt = noteList.Count - 1;
        //noteList.Remove();
        //Destroy(noteList[_noteCnt].gameObject);
       
    }
}
