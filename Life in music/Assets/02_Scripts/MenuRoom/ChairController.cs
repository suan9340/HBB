using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    public AudioSource audioSource = null;
    public AudioClip objectsound = null;

    [Space(20)]
    public GameObject defalutObj = null;
    public GameObject changeObj = null;

    [Space(20)]
    public Animator cardAnim = null;

    private bool isClick = false;
    private bool isMouseOn = false;
    private bool isShowCard = false;

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

    //private void OnMouseExit()
    //{
    //    if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
    //        return;

    //    OnObjectMouseExit();
    //}

    private void OnObjectMouseDown()
    {
        if (isClick)
        {
            return;
        }

        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);

        audioSource.PlayOneShot(objectsound);

        isClick = true;
        isShowCard = true;
        defalutObj.SetActive(false);
        changeObj.SetActive(true);

        cardAnim.SetBool("isShow", true);
    }

    private void OnObjectMouseOver()
    {
        if (isMouseOn)
            return;

        defalutObj.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
        changeObj.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);

        isMouseOn = true;
    }

    public void OnClick_OnObjectMouseExit()
    {
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
        cardAnim.SetBool("isShow", false);

        isClick = false;
        isMouseOn = false;

        defalutObj.transform.localScale = new Vector3(1f, 1f, 1f);
        changeObj.transform.localScale = new Vector3(1f, 1f, 1f);

        defalutObj.SetActive(true);
        changeObj.SetActive(false);
    }
}
