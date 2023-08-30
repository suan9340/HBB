using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClear : MonoBehaviour
{
    public bool isCCC = false;

    [Header("Color")]
    public Sprite[] colorSprite = null;


    private Animator myAnim = null;
    private SpriteRenderer mySprite = null;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();

        CheckingISClear();
    }

    private void CheckingISClear()
    {
        if (isCCC)
        {
            CompleteRhythm();
        }

    }

    public void CompleteRhythm()
    {
        mySprite.sprite = colorSprite[0];
        isCCC = true;
        //myAnim.SetTrigger("isCom");
    }
}
