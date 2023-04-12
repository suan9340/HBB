using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClear : MonoBehaviour
{
    public GameObject obj = null;
    private SpriteRenderer mySprite = null;

    public bool isCCC = false;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
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
            obj.SetActive(true);
            mySprite.color = new Color(0.67f, 0.67f, 0.67f);
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
