using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteTextAnimation : MonoBehaviour
{
    public DefineManager.NoteTimingCheck timingCheck;

    private Animator myAnim = null;
    private Text myTxt = null;
    private RectTransform myRect = null;

    public GameObject canUseRect = null;
    public GameObject cantUseRect = null;

    public Vector3 standardRect = Vector3.zero;
    private void OnEnable()
    {
        myAnim = GetComponent<Animator>();
        myTxt = GetComponent<Text>();
        myRect = GetComponent<RectTransform>();


        myRect.SetParent(cantUseRect.transform);
        CheckYShow();
    }

    public void SettingEnum(string _s)
    {
        timingCheck = NoteManager.Instance.GetTiming();
    }

    private void CheckYShow()
    {
        switch (timingCheck)
        {
            case DefineManager.NoteTimingCheck.Perfect:

                myTxt.text = "Perfect";
                myAnim.SetTrigger("isTextPerShow");

                break;



            case DefineManager.NoteTimingCheck.Good:

                myTxt.text = "Good";
                myAnim.SetTrigger("isTextGoodShow");

                break;




            case DefineManager.NoteTimingCheck.Bad:

                myTxt.text = "Bad";
                myAnim.SetTrigger("isTextBadShow");

                break;
        }

        Invoke(nameof(DestroyTxt), 0.5f);
    }

    private void DestroyTxt()
    {
        gameObject.SetActive(false);
        myRect.SetParent(canUseRect.transform);
        myRect.anchoredPosition = standardRect;
    }
}
