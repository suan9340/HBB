using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClear : MonoBehaviour
{
    public bool isCCC = false;

    [Header("Color")]
    public Sprite[] colorSprite = null;

    [Header("CompleteSize")]
    public Vector3 size = Vector3.zero;

    private Animator myAnim = null;
    private SpriteRenderer mySprite = null;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();

        CheckingISClear();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CompleteRhythm();
        }
    }

    private void CheckingISClear()
    {
        if (isCCC)
        {
            IsClear();
        }
        else
        {
            IsNotClear();
        }
    }

    public void IsClear()
    {
        transform.localScale = size;
    }

    public void IsNotClear()
    {

    }

    public void CompleteRhythm()
    {
        IsClear();
        myAnim.SetTrigger("isCom");
    }
}
