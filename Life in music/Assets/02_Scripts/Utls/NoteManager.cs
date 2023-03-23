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

    [Space(20)]
    [Header("--- NoteColider ---")]
    public RectTransform center = null;
    public List<RectTransform> timingRect = new List<RectTransform>();
    public Vector2[] timingBoxs = null;

    public GameObject noteEndImage = null;



    [Space(20)]
    [Header("--- Current ---")]
    public DefineManager.NoteTimingCheck noteTiming;
    private string timingText;

    private void Start()
    {
        EventManager.StartListening(ConstantManager.NOTE_IMAGE_INSTANCE, InstantiateNote);
        EventManager.StartListening(ConstantManager.NOTE_LIST_REMOVE, CheckTiming);

        SettingBox();
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
    private void SettingBox()
    {
        timingBoxs = new Vector2[timingRect.Count];

        for (int i = 0; i < timingRect.Count; i++)
        {
            timingBoxs[i].Set(center.transform.localPosition.x - timingRect[i].rect.width / 2,
             center.transform.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    private void CheckTiming()
    {
        if (noteList.Count == 0)
        {
            return;
        }

        for (int j = 0; j < noteList.Count; j++)
        {
            var _notepos = noteList[j].transform.localPosition.x - 920f;

            for (int i = 0; i < timingBoxs.Length; i++)
            {
                if (timingBoxs[i].x <= _notepos && _notepos <= timingBoxs[i].y)
                {
                    noteList[j].SetActive(false);
                    noteList.RemoveAt(j);

                    switch (i)
                    {
                        case 0:
                            noteTiming = DefineManager.NoteTimingCheck.Perfect;
                            timingText = "Perfect";
                            break;

                        case 1:
                            noteTiming = DefineManager.NoteTimingCheck.Good;
                            timingText = "Good";
                            break;

                        case 2:
                            noteTiming = DefineManager.NoteTimingCheck.Bad;
                            timingText = "Bad";
                            break;
                    }

                    EventManager<string>.TriggerEvent(ConstantManager.NOTE_CHECKING_TXT, timingText);
                    return;
                }
            }
        }
    }

    public void RemoveNote()
    {
        for (int i = 0; i < noteTrn.transform.childCount; i++)
        {
            Destroy(noteTrn.transform.GetChild(i).gameObject);
        }
        noteList.Clear();

        Destroy(noteEndImage);
    }

    public void SettingCenterImage(GameObject _obj)
    {
        Debug.Log("qwe");
        noteEndImage = Instantiate(_obj, center);
        noteEndImage.transform.SetParent(center.transform, false);
        noteEndImage.transform.localPosition = new Vector3(0, 0, 0);
    }

    public DefineManager.NoteTimingCheck GetTiming()
    {
        return noteTiming;
    }

}
