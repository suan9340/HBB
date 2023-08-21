using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEngine.Rendering.DebugUI;

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

    public float defaultSpeed = 0.03f;
    public float fastSpeed = 0.08f;

    [Space(20)]
    public AudioSource typingAudio = null;


    private string message;
    private float currentSpeed = 0f;

    private int textNum = 0;

    private bool isTyping = false;
    public bool isStoryStart = false;


    private void Start()
    {
        if (messagesList.Count > 0)
        {
            messagesList.Clear();
        }
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isStoryStart)
        {
            if (isTyping)
            {
                typingAudio.pitch = 1.3f;
                currentSpeed = fastSpeed;
            }
            else
            {
                if (textNum >= messagesList.Count - 1)
                {
                    textNum = 0;
                    messageObj.SetActive(false);
                    isStoryStart = false;
                    GameManager.Instance.SettingGameState(DefineManager.GameState.Playing);
                    SoundManager.Instance.CheckStageEndMusic();

                    return;
                }

                textNum++;
                typingAudio.pitch = 1;
                StartCoroutine(Typing(messagetxt, messagesList[textNum]));
            }
        }
    }

    public void FirstSetText()
    {
        isStoryStart = true;
        messageObj.SetActive(true);
        StartCoroutine(Typing(messagetxt, messagesList[textNum]));
    }

    public void SetChatting(List<string> _list)
    {
        messagesList = _list;
        textNum = 0;

    }

    //public void Text()
    //{
    //    if (messageObj == null)
    //    {
    //        Debug.LogError("messageObj is NULL!!!!");
    //        return;
    //    }

    //    //isChatStarting = true;
    //    //StartCoroutine(TextCor());
    //}

    private IEnumerator Typing(Text _text, string _message)
    {
        isTyping = true;
        typingAudio.Play();


        currentSpeed = defaultSpeed;

        for (int i = 0; i < _message.Length; i++)
        {
            messagetxt.text = _message.Substring(0, i + 1);
            yield return new WaitForSeconds(currentSpeed);
        }


        typingAudio.Stop();
        isTyping = false;
    }

    //private IEnumerator TextCor()
    //{
    //    messageObj.SetActive(true);

    //    for (int i = 0; i < messagesList.Count; i++)
    //    {
    //        yield return TextOutCor(messagesList[i]);
    //        yield return new WaitUntil(() => isClick == true);
    //    }

    //    GameManager.Instance.SettingGameState(DefineManager.GameState.Playing);


    //    messageObj.SetActive(false);
    //    isTyping = false;
    //    isChatStarting = false;

    //    SoundManager.Instance.CheckStageEndMusic();

    //    yield break;
    //}

    //private IEnumerator TextOutCor(string _input)
    //{
    //    isClick = false;
    //    isTyping = true;

    //    messagetxt.DOText(_input, 2f);

    //    yield return textTime;

    //    isTyping = false;
    //    yield break;
    //}


}
