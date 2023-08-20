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
    }

    private void Update()
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
            //obj.SetActive(true);    
            //mySprite.color = new Color(0.67f, 0.67f, 0.67f);
            mySprite.color = new Color(1, 1, 1, 1);
            mySprite.sprite = colorSprite[0];
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
}
