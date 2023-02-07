using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShellfishMove : MonoBehaviour
{
    public float targetpos;
    public float moveSpeed = 1f;

    [Space(10)]
    [Header("Check")]
    public bool isleft = false;
    public bool isright = false;
    public bool isup = false;
    public bool isdown = false;

    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isleft)
        {
            if (rect.position.x < targetpos) isleft = false;
            rect.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
        }
        else if (isright)
        {
            if (rect.position.x > targetpos) isright = false;
            rect.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
        }
        else if (isup)
        {
            if (rect.position.y > targetpos) isup = false;
            rect.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
        }
        else if (isdown)
        {
            if (rect.position.y < targetpos) isdown = false;
            rect.position += new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
        }
    }
}
