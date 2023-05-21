using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutController : MonoBehaviour
{
    public Text typingText = null;
    public float speed = 0.2f;
    public List<string> textList = new List<string>();

    private string message;

    private int textNum = 0;

    private bool isTextStart = false;

    public Animator menuAnim = null;
    private void Start()
    {
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        Invoke(nameof(Text), 5.27f);
        PlayerPrefs.SetInt("CheckFirst", 1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTextStart)
        {
            if (textNum >= textList.Count - 1)
            {
                isTextStart = false;
                menuAnim.SetTrigger("isClose");
                MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
                return;
            }

            NextText();
            Text();
        }
    }

    public void Text()
    {
        StartCoroutine(Typing(typingText, textList[textNum], speed));
    }

    private IEnumerator Typing(Text _text, string _message, float _speeed)
    {
        isTextStart = false;
        for (int i = 0; i < _message.Length; i++)
        {
            typingText.text = _message.Substring(0, i + 1);
            yield return new WaitForSeconds(_speeed);
        }

        isTextStart = true;
    }

    private void NextText()
    {
        textNum++;
    }
}
