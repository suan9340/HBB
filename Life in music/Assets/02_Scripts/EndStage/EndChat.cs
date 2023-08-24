using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndChat : MonoBehaviour
{
    [Header("--- Chatings List ---")]
    public GameObject messageObj = null;
    public Text messagetxt = null;

    [Space(20)]
    public List<string> messagesList = new List<string>();

    [Space(20)]
    public SpriteRenderer blackImage = null;

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
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isChatStarting)
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

        ReadyFadeBlackImage();
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

    private void ReadyFadeBlackImage()
    {
        Debug.Log("qwe");
        blackImage.gameObject.SetActive(true);
        //blackImage.DOFade(1, 1);
        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        GameSceneManager.Load(GameSceneManager.Scene.Room);
    }
}
