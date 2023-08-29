using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    #region SingleTon

    private static IntroText _instance = null;
    public static IntroText Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<IntroText>();
                if (_instance == null)
                {
                    _instance = new GameObject("IntroText").AddComponent<IntroText>();
                }
            }
            return _instance;
        }
    }


    #endregion

    public TextMeshProUGUI tutoTxt = null;
    private bool isTyping = false;
    public bool isChoice = true;

    [Space(20)]
    public float defaultSpeed = 0.08f;
    public float fastSpeed = 0.03f;

    [Space(20)]
    public bool isStroyStarting = false;

    [Space(20)]
    public AudioSource typingAudio = null;

    private float currentSpeed = 0f;

    public IntroCutScene introCutScene = null;

    private void Awake()
    {
        isChoice = true;
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.Space))) && isStroyStarting && isChoice)
        {
            if (isTyping)
            {
                currentSpeed = fastSpeed;
                typingAudio.pitch = 1.3f;
            }
            else
            {
                SetActiveFalseText();
                IntroCutScene.Instance.CheckNum();
            }
        }

    }


    public void SetActiveFalseText()
    {
        isStroyStarting = false;
        tutoTxt.text = " ";
    }

    public void TextingOut(string _input, int emojiIndex)
    {
        if (isTyping)
        {
            return;
        }

        StartCoroutine(TextOutCor(_input, emojiIndex));
    }

    private IEnumerator TextOutCor(string _input, int emojiIndex)
    {
        CheckingStart();
        typingAudio.pitch = 1f;
        isTyping = true;
        typingAudio.Play();

        currentSpeed = defaultSpeed;

        for (int i = 0; i < _input.Length; i++)
        {
            tutoTxt.text = _input.Substring(0, i + 1);
            yield return new WaitForSeconds(currentSpeed);
        }

        typingAudio.Stop();
        isTyping = false;

        if(emojiIndex != 8)
        {
            tutoTxt.SetText(_input + $" <sprite={emojiIndex}>");
        }
    }

    private void CheckingStart()
    {
        if (!isStroyStarting)
            isStroyStarting = true;
    }
}
