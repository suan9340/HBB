using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.Rendering.PostProcessing;
using UnityEditor.XR;

public class ChatMaanger : MonoSingleTon<ChatMaanger>
{
    [Header("--- Chatings List ---")]
    public List<string> messagesList = new List<string>();

    [Space(20)]
    public Text messagetxt = null;
    public GameObject messageObj = null;


    public bool isTyping = false;

    public bool isClick = false;
    private readonly WaitForSeconds textTime = new WaitForSeconds(2f);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isTyping)
        {
            isClick = true;
        }
    }

    public void SetChatting(List<string> _list)
    {
        messagesList = _list;
    }

    public void Text()
    {
        if (messageObj == null)
        {
            Debug.LogError("messageObj is NULL!!!!");
            return;
        }

        StartCoroutine(TextCor());
    }

    private IEnumerator TextCor()
    {
        if (isTyping) yield break;

        isTyping = true;
        messageObj.SetActive(true);

        for (int i = 0; i < messagesList.Count; i++)
        {
            messagetxt.DOText(messagesList[i], 3f);
            yield return textTime;

            yield return new WaitUntil(() => isClick == true);
            messagetxt.text = "";
            isClick = false;
        }

        GameManager.Instance.SettingGameState(DefineManager.GameState.Playing);


        messageObj.SetActive(false);
        isTyping = false;

        yield break;
    }
}
