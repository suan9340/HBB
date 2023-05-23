using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsFirstTuto : MonoBehaviour
{
    [Header("AudioUI")]
    [Tooltip("Audios BackGround Image!")]
    public Animator audioUIAnimator = null;
    private bool isOnAudioUI = false;
    private int tutoCnt;

    [Space(30)]
    public List<GameObject> tutoObj = new List<GameObject>();
    public AudioSource mySource = null;
    public AudioClip myClip = null;

    private int tutoNum = 0;

    private GameObject currentTutoObj = null;
    private void Start()
    {
        tutoCnt = tutoObj.Count + 1;
        OnClickTutoNext();
    }

    public void OnClickTutoNext()
    {
        CheckNum(true);
    }

    public void OnClickTutoBack()
    {
        CheckNum(false);
    }


    private void Tuto()
    {
        switch (tutoNum)
        {
            case 1:
                audioUIAnimator.SetBool("OnButton", false);
                CheckCurrentGameObj(tutoObj[0]);
                break;



            case 2:
                isOnAudioUI = true;
                audioUIAnimator.SetBool("OnButton", true);
                CheckCurrentGameObj(tutoObj[1]);
                break;



            case 3:
                if (!isOnAudioUI)
                    audioUIAnimator.SetBool("OnButton", true);
                CheckCurrentGameObj(tutoObj[2]);
                break;

            case 4:
                isOnAudioUI = false;
                audioUIAnimator.SetBool("OnButton", false);
                CheckCurrentGameObj(tutoObj[3]);
                break;


            case 5:
                SceneManager.LoadScene("Stage_01");
                break;
        }
    }

    private void CheckNum(bool _isPlus)
    {
        if (_isPlus)
        {
            var _input = tutoNum + 1;

            if (_input <= tutoCnt)
            {
                tutoNum++;
            }
        }
        else
        {
            var _iiput = tutoNum - 1;

            if (_iiput > 0)
            {
                tutoNum--;
            }
        }

        Tuto();
    }

    private void CheckCurrentGameObj(GameObject _obj)
    {
        mySource.PlayOneShot(myClip);
        if (currentTutoObj != null)
        {
            currentTutoObj.SetActive(false);
        }

        currentTutoObj = _obj;
        currentTutoObj.SetActive(true);
    }
}
