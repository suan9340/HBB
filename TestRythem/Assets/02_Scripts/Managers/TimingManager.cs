using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class TimingManager : MonoSingleTon<TimingManager>
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] private Transform center = null;
    [SerializeField] private RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    private void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.localPosition.x - timingRect[i].rect.width / 2,
                              center.localPosition.x + timingRect[i].rect.width / 2);
        }

    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float _notePosx = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= _notePosx && _notePosx <= timingBoxs[x].y)
                {
                    boxNoteList[i].GetComponent<Note>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log($"Hit {x}");
                    return;
                }
            }
        }

        Debug.Log("miss");
    }
}
