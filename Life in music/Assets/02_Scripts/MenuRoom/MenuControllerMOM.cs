using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerMOM : MonoBehaviour
{
    public AudioSource audioSource = null;
    public AudioClip objectsound = null;

    [Space(20)]
    public GameObject defalutObj = null;
    public GameObject changeObj = null;

    private bool isClick = false;
    private bool isMouseOn = false;

    protected void Start()
    {
        if ((defalutObj == null) || (changeObj == null))
        {
            Debug.Log("defaultObj is NULL");
            return;
        }

        defalutObj.SetActive(true);
        changeObj.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
            return;

        OnObjectMouseOver();
    }

    private void OnMouseDown()
    {
        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
            return;

        OnObjectMouseDown();
    }

    private void OnMouseExit()
    {
        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
            return;

        OnObjectMouseExit();
    }

    protected virtual void OnObjectMouseDown()
    {
        if (isClick)
        {
            return;
        }

        audioSource.PlayOneShot(objectsound);

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
