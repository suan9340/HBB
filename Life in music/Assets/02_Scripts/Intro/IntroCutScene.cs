using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IntroCutScene : MonoBehaviour
{
    #region SingleTon

    private static IntroCutScene _instance = null;
    public static IntroCutScene Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<IntroCutScene>();
                if (_instance == null)
                {
                    _instance = new GameObject("IntroCutScene").AddComponent<IntroCutScene>();
                }
            }
            return _instance;
        }
    }


    #endregion

    public List<string> introText = new List<string>();
    public List<string> selectText = new List<string>();


    [Space(20)]
    public List<GameObject> introObj = new List<GameObject>();
    public GameObject IntroObj = null;

    private IntroSelectSO introSelectSO = null;

    [Space(20)]
    public List<AudioClip> introClip = new List<AudioClip>();
    public AudioSource mySource = null;

    [Space(20)]
    public int introTextnum = 0;
    public int introObjNum = 0;

    public TextMeshProUGUI backText;

    public GameObject selectUI = null;

    [Space(20)]
    public Button selecButton1 = null;
    public Button selecButton2 = null;


    [Space(20)]
    public TextMeshProUGUI selecButtonText1 = null;
    public TextMeshProUGUI selecButtonText2 = null;


    [Space(20)]
    public IntroText introTextScript;
    public TextMeshProUGUI newTutoText;
    private int emojiIndex = 3;


    [Space(20)]
    public AudioSource selectClickSound;
    public AudioSource selectShowSound;


    [Space(20)]
    [Header("Select")]
    public bool isSoTextStart = false;
    public int selectNum = 0;
    public List<string> introSelectSmallList = new List<string>();


    private void Awake()
    {
        introObj[1].GetComponent<Animator>().SetBool("ReSleep", true);
    }
    private void Start()
    {
        CheckNum();
        mySource.PlayOneShot(introClip[0]);
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        PlayerPrefs.SetInt("CheckFirst", 1);

        introSelectSO = Resources.Load<IntroSelectSO>("SO/Intro/IntroSelectSO");
    }

    void SelectTextBox()
    {
        selectShowSound.Play();

        switch (introTextnum)
        {
            case 3:
                AddListen(0);
                break;

            case 9:
                RemoveListen(5, 3);
                AddListen(1);
                break;

            case 14:
                RemoveListen(9, 11);
                AddListen(2);
                break;

            case 22:
                RemoveListen(16, 14);
                AddListen(3);
                break;
        }
    }

    private void FadeInIntroObj(GameObject _obj)
    {
        if (_obj == null)
        {
            Debug.LogError("Obj is NULL!!");
            return;
        }

        _obj.GetComponent<Animator>().SetTrigger("isIntroFadeIn");
        mySource.Stop();
    }

    private void ShowText(int emojiIndex)
    {
        IntroText.Instance.TextingOut(introText[introTextnum], emojiIndex);
    }

    private void AddListen(int _idx)
    {
        isSoTextStart = true;

        selecButton1.onClick.AddListener(() => AddButtonClickListener(_idx, 1));
        selecButton2.onClick.AddListener(() => AddButtonClickListener(_idx, 2));
    }

    private void RemoveListen(int _num1, int _num2)
    {
        selecButton1.onClick.RemoveAllListeners();
        selecButton2.onClick.RemoveAllListeners();
    }

    private void AddButtonClickListener(int _idx, int _num)
    {
        selectClickSound.Play();

        var _tt = introSelectSO.textList[_idx];
        if (_num == 1)
        {
            introSelectSmallList = _tt.first;
        }
        else
        {
            introSelectSmallList = _tt.second;
        }

        selectNum = 0;
        CutSceneSelect(false);
        //introTextnum = newIntroTextnum;
        CheckNum();
    }

    private void CutSceneSelect(bool setActive)
    {
        var _a = introTextnum;
        backText.text = introText[_a];

        selectUI.gameObject.SetActive(setActive);
        introTextScript.gameObject.GetComponent<IntroText>().isChoice = !setActive;
    }

    public void CheckNum()
    {
        emojiIndex = 8;

        if (isSoTextStart)
        {
            CheckIntroNum();
            return;
        }

        switch (introTextnum)
        {
            case 0:
                FadeInIntroObj(introObj[introObjNum]);
                break;


            case 1:
                introObj[1].GetComponent<Animator>().SetBool("ReSleep", false);
                emojiIndex = 4;
                break;


            case 2:
                introObj[1].gameObject.SetActive(false);
                break;


            case 3:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText1.text = selectText[0];
                selecButtonText2.text = selectText[1];
                mySource.Stop();
                break;


            case 4:
                introObj[1].gameObject.SetActive(true);
                introObj[1].GetComponent<Animator>().SetBool("ReSleep", true);
                emojiIndex = 5;
                break;


            case 5:
                emojiIndex = 3;
                introObj[1].GetComponent<Animator>().SetBool("ReSleep", false);
                FadeInIntroObj(introObj[2]);
                break;


            case 7:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText1.text = selectText[2];
                selecButtonText2.text = selectText[3];
                break;


            case 10:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText1.text = selectText[4];
                selecButtonText2.text = selectText[5];
                break;


            case 11:
                mySource.PlayOneShot(introClip[1]);
                break;


            case 12:
                FadeInIntroObj(introObj[3]);
                emojiIndex = 6;
                break;


            case 14:
                FadeInIntroObj(introObj[4]);
                mySource.PlayOneShot(introClip[1]);
                emojiIndex = 3;
                break;


            case 16:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText1.text = selectText[6];
                selecButtonText2.text = selectText[7];
                break;


            case 18:
                emojiIndex = 7;
                foreach (var _introObj in introObj)
                {
                    if (_introObj == introObj[1])
                    {
                        _introObj.GetComponent<Animator>().SetBool("ReSleep", false);
                    }
                    else
                    {
                        _introObj.GetComponent<Animator>().SetTrigger("isIntroFadeOut");
                    }

                }
                break;


            case 20:
                emojiIndex = 1;
                break;


            default:
                break;
        }


        if (introTextnum >= introText.Count - 1)
        {
            IntroObj.SetActive(false);
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
            return;
        }

        ShowText(emojiIndex);
        introTextnum++;
    }

    public void CheckIntroNum()
    {
        emojiIndex = 8;

        if (selectNum >= introSelectSmallList.Count)
        {
            isSoTextStart = false;
            CheckNum();
            return;
        }

        IntroText.Instance.TextingOut(introSelectSmallList[selectNum], emojiIndex);
        selectNum++;
    }
}
