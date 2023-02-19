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

    private readonly WaitForSeconds rhythmEffectSec = new WaitForSeconds(0.3f);
    private void Start()
    {
        EventManager.StartListening(ConstantManager.START_RHYTHM, ReadyRhythm);
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
        else
        {
            if (isReadyRhythm == false)
            {
                isReadyRhythm = true;
                readyRhythmAnimator.SetBool("OnReady", true);
            }
            else
            {
                isReadyRhythm = false;
                readyRhythmAnimator.SetBool("OnReady", false);
            }
        }
    }

    public void RhythmNoteEffect()
    {
        StartCoroutine(EffectNoteCoroutine());
    }
    
    private IEnumerator EffectNoteCoroutine()
    {
        rhythmEffectImage.enabled = true;
        yield return rhythmEffectSec;
        rhythmEffectImage.enabled = false;
        yield break;
    }
}
