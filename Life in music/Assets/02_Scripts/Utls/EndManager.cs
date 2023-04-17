using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoSingleTon<EndManager>
{
    [Space(20)]
    [Header("StageEndAnimation")]
    public Animator stageEnd = null;
    private bool isStageEnd = false;

    [Space(20)]
    [Header("Tuto Text")]
    public List<string> stageEndText = new List<string>();

    [Space(20)]
    [Header("Objects")]
    public GameObject menuBtn = null;

    public EndChat endChat;

    private void Start()
    {
        if (endChat == null)
        {
            endChat = GameObject.Find("EndChat").GetComponent<EndChat>();
        }
        //SetStageText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetStageText();
        }
    }

    private void SetStageText()
    {
        endChat.SetChatting(stageEndText);
        OnStartStageEnd();
        Invoke(nameof(StartStageEndText), 1.4f);
    }

    private void StartStageEndText()
    {
        Debug.Log("Start");
        endChat.Text();
    }

    private void OnStartStageEnd()
    {
        if (isStageEnd)
        {
            return;
        }

        GameManager.Instance.SettingGameState(DefineManager.GameState.CantClick);
        isStageEnd = true;
        stageEnd.SetTrigger("isStageEnd");
    }
}
