using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClear : MonoBehaviour
{
    public GameObject obj = null;
    private SpriteRenderer mySprite = null;

    public bool isCCC = false;

    [Space(20)]
    public StageCheckSO stageCheckSo = null;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();

        if (stageCheckSo == null)
        {
            stageCheckSo = Resources.Load<StageCheckSO>("SO/RhythmCheck/CheckSO");
        }
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

    private void CheckCurrentIsClear()
    {

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

    public bool CheckIsClear(int num)
    {
        var _isClearing = stageCheckSo.cObject[num].isClear;

        //Debug.Log(_isClearing);
        if (_isClearing)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
