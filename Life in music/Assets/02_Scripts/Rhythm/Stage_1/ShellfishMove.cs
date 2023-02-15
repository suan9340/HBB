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

    [Header("NoteAnimation")]
    public Animator noteAnimation = null;
    public bool isFirst = false;

    private RectTransform rect;
    private Transform trn;
    private Canvas canvas;

    private void OnEnable()
    {
        //canvas = GameObject.FindWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
        //trn = GetComponent<Transform>();

        //if (!isFirst)
        //    trn.SetParent(canvas.transform, false);
    }

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        noteAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isleft)
        {
            if (rect.anchoredPosition.x <= targetpos)
            {
                isleft = false;
                rect.anchoredPosition = new Vector2(targetpos, rect.anchoredPosition.y);
                AddList(gameObject);
            }
            else
            {
                rect.anchoredPosition += new Vector2(-10, 0) * moveSpeed * Time.deltaTime;
            }


        }
        else if (isright)
        {


            if (rect.anchoredPosition.x >= targetpos)
            {
                isright = false;
                rect.anchoredPosition = new Vector2(targetpos, rect.anchoredPosition.y);
                AddList(gameObject);
            }
            else
            {
                rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
            }



        }
        else if (isup)
        {


            if (rect.anchoredPosition.y >= targetpos)
            {
                isup = false;
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, targetpos);
                AddList(gameObject);
            }
            else
            {
                rect.anchoredPosition += new Vector2(0, 10) * moveSpeed * Time.deltaTime;
            }



        }
        else if (isdown)
        {


            if (rect.anchoredPosition.y <= targetpos)
            {
                isdown = false;
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, targetpos);
                AddList(gameObject);
            }
            else
            {
                rect.anchoredPosition += new Vector2(0, -10) * moveSpeed * Time.deltaTime;
            }



        }
    }

    private void AddList(GameObject _obj)
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.SHELLFISHLIST_ADD, _obj);
    }

    public void ShellfishDown()
    {
        noteAnimation.SetTrigger("isDown");
    }
}
