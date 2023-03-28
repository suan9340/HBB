using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChatMaanger : MonoSingleTon<ChatMaanger>
{
    [Header("--- Chatings List ---")]
    public GameObject chatingObj = null;
    public List<string> messagesList = new List<string>();

    [Space(20)]
    public Text messagetxt = null;
    public GameObject messageObj = null;


    private bool isTyping = false;

    private bool isClick = false;
    private readonly WaitForSeconds textTime = new WaitForSeconds(2f);

    private void Start()
    {
        if (messagesList.Count > 0)
        {
            messagesList.Clear();
        }

        messagetxt.text = "";
    }

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

        messagetxt.text = "";
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
