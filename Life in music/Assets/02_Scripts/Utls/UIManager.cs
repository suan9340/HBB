using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region SingleTon

    private static UIManager _instance = null;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("UIManager").AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }

    #endregion

    [Header("AudioUI")]
    [Tooltip("Audios BackGround Image!")]
    public Animator audioUIAnimator = null;
    private bool isOnAudioUI = false;

    [Space(10)]
    [Header("ReadyRhythmUI")]
    public Animator readyRhythmAnimator = null;
    public GameObject inGameUIs = null;
    private bool isReadyRhythm = false;


    [Space(10)]
    [Header("RhythmEffectImage")]
    public Image rhythmEffectImage = null;


    [Space(20)]
    [Header("RhythmNoteShow")]
    public Animator rhythmNotePanel = null;
    private bool isRhythmPanel = false;


    [Space(20)]
    [Header("StageEnd")]
    public GameObject stageEndObj = null;

    private readonly WaitForSeconds rhythmEffectSec = new WaitForSeconds(0.1f);

    private void Start()
    {
        EventManager.StartListening(ConstantManager.START_RHYTHM, ReadyRhythm);
        EventManager.StartListening(ConstantManager.START_RHYTHM_PANEL, ReadyRhythmPanel);

        stageEndObj.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.StopListening(ConstantManager.START_RHYTHM, ReadyRhythm);
        EventManager.StopListening(ConstantManager.START_RHYTHM_PANEL, ReadyRhythmPanel);
    }

    public void OnclickAudioUI()
    {
        if (audioUIAnimator == null)
        {
            Debug.LogWarning("audioBackGroundImage ((AudioUI)) is NULL!!!");
            return;
        }
        else
        {
            if (isOnAudioUI == false)
            {
                isOnAudioUI = true;
                audioUIAnimator.SetBool("OnButton", true);

            }
            else
            {
                isOnAudioUI = false;
                audioUIAnimator.SetBool("OnButton", false);
            }
        }
    }


    private void ReadyRhythm()
    {

        if (readyRhythmAnimator == null || inGameUIs == null)
        {
            Debug.LogWarning("readyRhythmAnimator ((ReadyRhythmUI)) is NULL!!!");
            return;
        }

        isReadyRhythm = !isReadyRhythm;
        if (isReadyRhythm)
        {
            inGameUIs.SetActive(false);
            readyRhythmAnimator.SetBool("OnReady", true);
        }
        else
        {
            inGameUIs.SetActive(true);
            readyRhythmAnimator.SetBool("OnReady", false);
        }
    }

    private void ReadyRhythmPanel()
    {
        if (rhythmNotePanel == null)
        {
            Debug.LogWarning("rhythmNotePanel  is NULL!!!");
            return;
        }

        isRhythmPanel = !isRhythmPanel;

        if (isReadyRhythm)
        {
            rhythmNotePanel.SetBool("ispanelOn", true);
        }
        else
        {
            rhythmNotePanel.SetBool("ispanelOn", false);
        }
    }

    public void RhythmNoteEffect()
    {
        StartCoroutine(EffectNoteCoroutine());
    }

    private IEnumerator EffectNoteCoroutine()
    {
        rhythmEffectImage.enabled
            = true;
        yield return rhythmEffectSec;
        rhythmEffectImage.enabled = false;
        yield break;
    }

    public void OnClickStageEnd(bool _isTrue)
    {
        stageEndObj.SetActive(_isTrue);
    }
}
