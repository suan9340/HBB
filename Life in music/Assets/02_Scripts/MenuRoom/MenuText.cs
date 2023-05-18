using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuText : MonoBehaviour
{
    public Text typingText = null;
    public float speed = 0.2f;
    public List<string> textList = new List<string>();

    private string message;
    private void Start()
    {
        typingText = GetComponent<Text>();
        Text();
    }

    private void Text()
    {
        StartCoroutine(Typing(typingText, textList[0], speed));

    }

    private IEnumerator Typing(Text _text, string _message, float _speeed)
    {
        for (int i = 0; i < _message.Length; i++)
        {
            typingText.text = _message.Substring(0, i + 1);
            yield return new WaitForSeconds(_speeed);
        }

        Debug.Log("End");
    }
}
