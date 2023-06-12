using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class TutoManager : MonoBehaviour
{
    #region SingleTon

    private static TutoManager _instance = null;
    public static TutoManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TutoManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("TutoManager").AddComponent<TutoManager>();
                }
            }
            return _instance;
        }
    }

    #endregion

    public Text tutoTxt = null;
    private bool isTyping = false;

    [Space(20)]
    public float defaultSpeed = 0.08f;
    public float fastSpeed = 0.03f;

    [Space(20)]
    public bool isStroyStarting = false;

    private float currentSpeed = 0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isStroyStarting)
        {
            if (isTyping)
            {
                currentSpeed = fastSpeed;
            }
        }
    }

    public void SetActiveFalseText()
    {
        isStroyStarting = false;
        tutoTxt.text = " ";
        //tutoTxt.gameObject.SetActive(false);
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
        CheckingStart();
        isTyping = true;
        currentSpeed = defaultSpeed;

        for (int i = 0; i < _input.Length; i++)
        {
            tutoTxt.text = _input.Substring(0, i + 1);
            yield return new WaitForSeconds(currentSpeed);
        }

        isTyping = false;
    }

    private void CheckingStart()
    {
        if (!isStroyStarting)
            isStroyStarting = true;
    }
}
