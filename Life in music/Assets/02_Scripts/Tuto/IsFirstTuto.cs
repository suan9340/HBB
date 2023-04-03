using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFirstTuto : MonoBehaviour
{
    [Header("AudioUI")]
    [Tooltip("Audios BackGround Image!")]
    public Animator audioUIAnimator = null;
    private bool isOnAudioUI = false;


    [Space(30)]
    public List<GameObject> tutoObj = new List<GameObject>();

    int tutoNum = 0;
    private void Start()
    {
        OnClickTutoNext();
    }

    public void OnClickTutoNext()
    {
        tutoNum++;
        Tuto();
    }

    public void OnClickTutoBack()
    {
        tutoNum--;
        Tuto();
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


    private void Tuto()
    {
        switch (tutoNum)
        {
            case 0:
                tutoObj[0].gameObject.SetActive(true);
                break;



            case 1:
                OnclickAudioUI();
                tutoObj[0].gameObject.SetActive(false);
                tutoObj[1].gameObject.SetActive(true);
                break;



            case 2:
                tutoObj[1].gameObject.SetActive(false);
                tutoObj[2].gameObject.SetActive(true);
                break;

            case 3:
                OnclickAudioUI();
                tutoObj[2].gameObject.SetActive(false);
                tutoObj[3].gameObject.SetActive(true);
                break;
        }


    }
}
