using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class TutoManager : MonoSingleTon<TutoManager>
{
    public Text tutoTxt = null;
    private bool isTyping = false;

    private readonly WaitForSeconds textWait = new WaitForSeconds(2f);
    public void SetActiveTrueText()
    {
        tutoTxt.text = "0";
        if (!tutoTxt.gameObject.activeSelf)
            tutoTxt.gameObject.SetActive(true);
    }

    public void SetActiveFalseText()
    {
        tutoTxt.text = " ";
        tutoTxt.gameObject.SetActive(false);
    }

    public bool IsTyping
    {
        get { return isTyping; }
    }

    public void TextingOut(string _input)
    {
        if (isTyping)
        {
            return;
        }

        StartCoroutine(TextOutCor(_input));
    }

    private IEnumerator TextOutCor(string _input)
    {
        isTyping = true;

        SetActiveTrueText();

        tutoTxt.DOText(_input, 2f);

        yield return textWait;
        isTyping = false;

        yield break;
    }


}
