using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleTon<UIManager>
{
    [Header("AudioUI")]
    [Tooltip("Audios BackGround Image!")]
    public Animator audioUIAnimator = null;
    private bool isOnAudioUI = false;

    [Space(10)]
    [Header("ReadyRhythmUI")]
    public Animator readyRhythmAnimator = null;
    private bool isReadyRhythm = false;


    [Space(10)]
    [Header("RhythmEffectImage")]
    public Image rhythmEffectImage = null;


    [Space(20)]
    [Header("RhythmNoteShow")]
    public Animator rhythmNotePanel = null;
    private bool isRhythmPanel = false;

    [Space(20)]
    [Header("RhythmChangeImage")]
    public Image changePanelImage = null;


    private readonly WaitForSeconds rhythmEffectSec = new WaitForSeconds(0.1f);

    private void Start()
    {
        EventManager.StartListening(ConstantManager.START_RHYTHM, ReadyRhythm);
        EventManager.StartListening(ConstantManager.START_RHYTHM_PANEL, ReadyRhythmPanel);
        EventManager<bool>.StartListening(ConstantManager.RHYTHM_CHANGE_UI, PannelChange);
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

        if (readyRhythmAnimator == null)
        {
            Debug.LogWarning("readyRhythmAnimator ((ReadyRhythmUI)) is NULL!!!");
            return;
        }

        isReadyRhythm = !isReadyRhythm;
        if (isReadyRhythm)
        {
            readyRhythmAnimator.SetBool("OnReady", true);
        }
        else
        {
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

    private void PannelChange(bool _isBlack)
    {
        if (_isBlack)
        {
            changePanelImage.color = new Color(0, 0, 0, 0.3f);
        }
        else
        {
            changePanelImage.color = new Color(1, 1, 1, 0.3f);
        }
    }
}
