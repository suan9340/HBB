using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRightMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    private RectTransform rect;

    private bool isClear = false;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isClear)
            return;

        if (rect.anchoredPosition.x >= 1800f)
        {
            isClear = true;
            EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
        }

        rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
    }
}
