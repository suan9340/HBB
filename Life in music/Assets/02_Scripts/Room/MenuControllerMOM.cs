using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerMOM : MonoBehaviour
{
    public GameObject defalutObj = null;
    public GameObject changeObj = null;

    private bool isClick = false;
    private bool isMouseOn = false;

    private void Start()
    {
        if (defalutObj == null)
        {
            Debug.Log("defaultObj is NULL");
        }

        if (changeObj == null)
        {
            Debug.Log("changeObj is NULL");
        }

        defalutObj.SetActive(true);
        changeObj.SetActive(false);
    }

    private void OnMouseOver()
    {
        OnObjectMouseOver();
    }

    private void OnMouseDown()
    {
        OnObjectMouseDown();
    }

    private void OnMouseExit()
    {
        OnObjectMouseExit();
    }

    protected virtual void OnObjectMouseDown()
    {
        if (isClick)
        {
            return;
        }

        isClick = true;
        defalutObj.SetActive(false);
        changeObj.SetActive(true);
    }

    protected virtual void OnObjectMouseOver()
    {
        if (isMouseOn)
            return;

        defalutObj.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        changeObj.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);

        isMouseOn = true;
    }

    protected virtual void OnObjectMouseExit()
    {
        isClick = false;
        isMouseOn = false;

        defalutObj.transform.localScale = new Vector3(1f, 1f, 1f);
        changeObj.transform.localScale = new Vector3(1f, 1f, 1f);

        defalutObj.SetActive(true);
        changeObj.SetActive(false);
    }
}
