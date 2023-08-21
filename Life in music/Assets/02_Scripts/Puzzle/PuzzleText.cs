using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleText : MonoBehaviour
{
    #region SingleTon

    private static PuzzleText _instance = null;
    public static PuzzleText Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PuzzleText>();
                if (_instance == null)
                {
                    _instance = new GameObject("PuzzleText").AddComponent<PuzzleText>();
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

    [Space(20)]
    public AudioSource typingAudio = null;

    private float currentSpeed = 0f;

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isStroyStarting)
        {
            if (isTyping)
            {
                currentSpeed = fastSpeed;
                typingAudio.pitch = 1.3f;
            }
            else
            {
                SetActiveFalseText();
                PuzzleManager.Instance.CanClickPuzzles();
            }
        }

    }


    public void SetActiveFalseText()
    {
        isStroyStarting = false;
        tutoTxt.text = " ";
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
    }

    private void CheckingStart()
    {
        if (!isStroyStarting)
            isStroyStarting = true;
    }
}
