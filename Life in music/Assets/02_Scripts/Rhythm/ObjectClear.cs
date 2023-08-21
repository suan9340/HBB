using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClear : MonoBehaviour
{
    public GameObject obj = null;

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
            IsClear();
        }
        else
        {
            IsNotClear();
        }
    }

    public void IsClear()
    {
        if (CheckingNull())
        {
            mySprite.color = new Color(1, 1, 1, 1);
            mySprite.sprite = colorSprite[0];
            Debug.Log("qq");
        }
    }

    public void IsNotClear()
    {
        if (CheckingNull())
        {
            obj.SetActive(false);
            mySprite.color = new Color(1f, 1f, 1f);
        }
    }

    private bool CheckingNull()
    {
        if (obj == null)
        {
            Debug.Log("OBj is NULL");
            return false;
        }
        return true;
    }

    public void CompleteRhythm()
    {
        isCCC = true;

        mySprite.color = new Color(1, 1, 1, 1);
        mySprite.sprite = colorSprite[0];

    }
}
