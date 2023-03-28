using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class TutoManager : MonoSingleTon<TutoManager>
{
    public Text tutoTxt = null;


    private readonly WaitForSeconds textWait = new WaitForSeconds(3f);
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

    public void TextingOut(string _input)
    {
        StartCoroutine(TextOutCor(_input));
    }

    private IEnumerator TextOutCor(string _input)
    {
        SetActiveTrueText();

        tutoTxt.DOText(_input, 3f);

        yield return textWait;

        yield break;
    }

}
