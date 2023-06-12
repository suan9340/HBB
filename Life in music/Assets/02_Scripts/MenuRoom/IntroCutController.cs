using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutController : MonoBehaviour
{
    public Text typingText = null;
    public float defaultSpeed = 0.03f;
    public float fastSpeed = 0.03f;

    [Space(20)]
    public List<string> textList = new List<string>();

    [Space(20)]
    public AudioSource typingSound = null;

    private string message;
    private float currentSpeed = 0f;

    private int textNum = 0;

    private bool isTyping = false;
    private bool isStroyStart = false;

    public Animator menuAnim = null;
    private void Start()
    {
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        Invoke(nameof(SettingTutoTextStart), 5.27f);
        PlayerPrefs.SetInt("CheckFirst", 1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isStroyStart)
        {
            if (isTyping)
            {
                currentSpeed = fastSpeed;
                typingSound.pitch = 1.3f;
            }
            else
            {
                if (textNum >= textList.Count - 1)
                {
                    isStroyStart = false;
                    isTyping = false;
                    menuAnim.SetTrigger("isClose");
                    MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
                    return;
                }

                NextText();
                Text();

            }
        }
    }

    public void SettingTutoTextStart()
    {
        isStroyStart = true;
        StartCoroutine(Typing(typingText, textList[textNum]));
    }

    public void Text()
    {
        StartCoroutine(Typing(typingText, textList[textNum]));
    }

    private IEnumerator Typing(Text _text, string _message)
    {
        isTyping = true;
        typingSound.Play();

        currentSpeed = defaultSpeed;

        for (int i = 0; i < _message.Length; i++)
        {
            typingText.text = _message.Substring(0, i + 1);
            yield return new WaitForSeconds(currentSpeed);
        }

        typingSound.Stop();
        isTyping = false;
    }

    private void NextText()
    {
        textNum++;
        typingSound.pitch = 1;
    }
}
