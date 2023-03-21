using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRightMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
    }
}
