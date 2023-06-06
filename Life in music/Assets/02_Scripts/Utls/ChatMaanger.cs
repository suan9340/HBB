using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChatMaanger : MonoBehaviour
{
    #region SingleTon

    private static ChatMaanger _instance = null;
    public static ChatMaanger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ChatMaanger>();
                if (_instance == null)
                {
                    _instance = new GameObject("ChatMaanger").AddComponent<ChatMaanger>();
                }
            }
            return _instance;
        }
    }

    #endregion

    [Header("--- Chatings List ---")]
    public GameObject messageObj = null;
    public Text messagetxt = null;

    [Space(20)]
    public List<string> messagesList = new List<string>();

    private bool isChatStarting = false;
    private bool isTyping = false;
    private bool isClick = false;

    private readonly WaitForSeconds textTime = new WaitForSeconds(2f);

    private void Start()
    {
        if (messagesList.Count > 0)
        {
            messagesList.Clear();
        }

        SetActiveTrueText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isChatStarting)
        {
            if (isTyping)
            {
                return;
            }

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

        isChatStarting = true;
        StartCoroutine(TextCor());
    }

    private void SetActiveTrueText()
    {
        messagetxt.text = " ";
    }

    private IEnumerator TextCor()
    {
        messageObj.SetActive(true);

        for (int i = 0; i < messagesList.Count; i++)
        {
            yield return TextOutCor(messagesList[i]);
            yield return new WaitUntil(() => isClick == true);
        }

        GameManager.Instance.SettingGameState(DefineManager.GameState.Playing);


        messageObj.SetActive(false);
        isTyping = false;
        isChatStarting = false;

        SoundManager.Instance.CheckStageEndMusic();

        yield break;
    }

    private IEnumerator TextOutCor(string _input)
    {
        isClick = false;
        isTyping = true;
        SetActiveTrueText();

        messagetxt.DOText(_input, 2f);

        yield return textTime;

        isTyping = false;
        yield break;
    }


}
