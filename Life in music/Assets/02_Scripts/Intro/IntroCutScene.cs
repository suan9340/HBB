using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.PlayerLoop.PreLateUpdate;

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
    public Button selecButton3 = null;
    public Button selecButton4 = null;
    public Button selecButton5 = null;
    public Button selecButton6 = null;
    public Button selecButton7 = null;
    public Button selecButton8 = null;

    [Space(20)]
    public TextMeshProUGUI selecButtonText1 = null;
    public TextMeshProUGUI selecButtonText2 = null;
    public TextMeshProUGUI selecButtonText3 = null;
    public TextMeshProUGUI selecButtonText4 = null;
    public TextMeshProUGUI selecButtonText5 = null;
    public TextMeshProUGUI selecButtonText6 = null;
    public TextMeshProUGUI selecButtonText7 = null;
    public TextMeshProUGUI selecButtonText8 = null;

    public IntroText introTextScript;
    public TextMeshProUGUI newTutoText;
    private int emojiIndex = 3;

    private void Awake()
    {
        introObj[1].GetComponent<Animator>().SetBool("ReSleep", true);
    }
    private void Start()
    {
        ShowText(emojiIndex);
        ShowIntroObj();
        mySource.PlayOneShot(introClip[0]);
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        PlayerPrefs.SetInt("CheckFirst", 1);
    }

    void SelectTextBox()
    {
        switch (introTextnum)
        {
            case 2:

                #region SetActive
                selecButton1.gameObject.SetActive(true);
                selecButton2.gameObject.SetActive(true);
                selecButton3.gameObject.SetActive(false);
                selecButton4.gameObject.SetActive(false);
                selecButton5.gameObject.SetActive(false);
                selecButton6.gameObject.SetActive(false);
                selecButton7.gameObject.SetActive(false);
                selecButton8.gameObject.SetActive(false);

                #endregion

                selecButton1.onClick.AddListener(() => AddButtonClickListener(5));
                selecButton2.onClick.AddListener(() => AddButtonClickListener(3));
                break;

            case 8:

                #region SetActive
                selecButton1.gameObject.SetActive(false);
                selecButton2.gameObject.SetActive(false);
                selecButton3.gameObject.SetActive(true);
                selecButton4.gameObject.SetActive(true);
                selecButton5.gameObject.SetActive(false);
                selecButton6.gameObject.SetActive(false);
                selecButton7.gameObject.SetActive(false);
                selecButton8.gameObject.SetActive(false);
                #endregion

                selecButton3.onClick.AddListener(() => AddButtonClickListener(9));
                selecButton4.onClick.AddListener(() => AddButtonClickListener(11));
                break;

            case 13:

                #region SetActive
                selecButton1.gameObject.SetActive(false);
                selecButton2.gameObject.SetActive(false);
                selecButton3.gameObject.SetActive(false);
                selecButton4.gameObject.SetActive(false);
                selecButton5.gameObject.SetActive(true);
                selecButton6.gameObject.SetActive(true);
                selecButton7.gameObject.SetActive(false);
                selecButton8.gameObject.SetActive(false);

                #endregion

                selecButton5.onClick.AddListener(() => AddButtonClickListener(16));
                selecButton6.onClick.AddListener(() => AddButtonClickListener(14));
                break;

            case 21:

                #region SetActive
                selecButton1.gameObject.SetActive(false);
                selecButton2.gameObject.SetActive(false);
                selecButton3.gameObject.SetActive(false);
                selecButton4.gameObject.SetActive(false);
                selecButton5.gameObject.SetActive(false);
                selecButton6.gameObject.SetActive(false);
                selecButton7.gameObject.SetActive(true);
                selecButton8.gameObject.SetActive(true);
                #endregion


                selecButton7.onClick.AddListener(() => AddButtonClickListener(22));
                selecButton8.onClick.AddListener(() => AddButtonClickListener(25));
                break;
        };
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

    private void ShowIntroObj()
    {
        FadeInIntroObj(introObj[introObjNum]);
    }

    private void AddButtonClickListener(int newIntroTextnum)
    {
        CutSceneSelect(false);
        introTextnum = newIntroTextnum;
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

        switch (introTextnum)
        {
            case 0:
                introObj[1].GetComponent<Animator>().SetBool("ReSleep", false);
                emojiIndex = 4;
                break;

            case 1:
                introObj[1].gameObject.SetActive(false);
                break;

            case 2:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText1.text = selectText[0];
                selecButtonText2.text = selectText[1];
                break;

            case 3:
                mySource.Stop();
                break;

            case 4:
                emojiIndex = 5;
                break;

            case 5:
                introObj[1].gameObject.SetActive(true);
               introObj[1].GetComponent<Animator>().SetBool("ReSleep", true);
                break;

            case 6:
                emojiIndex = 3;
               introObj[1].GetComponent<Animator>().SetBool("ReSleep", false);
               FadeInIntroObj(introObj[2]);
                break;

            case 8:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText3.text = selectText[2];
                selecButtonText4.text = selectText[3];
                break;
            case 11:
                emojiIndex = 2;
                break;
            case 13:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText5.text = selectText[4];
                selecButtonText6.text = selectText[5];
                break;

            case 15:

                mySource.PlayOneShot(introClip[1]);
                break;

            case 16:
                FadeInIntroObj(introObj[3]);
                emojiIndex = 6;
                break;


            case 18:
                FadeInIntroObj(introObj[4]);
                mySource.PlayOneShot(introClip[1]);
                emojiIndex = 3;
                break;

            case 19:
                emojiIndex = 0;
                break;

            case 20:
                FadeInIntroObj(introObj[5]);

                break;

            case 21:
                SelectTextBox();
                CutSceneSelect(true);
                selecButtonText7.text = selectText[6];
                selecButtonText8.text = selectText[7];
                break;

            case 24:
                FadeInIntroObj(introObj[6]);
                introObj[6].SetActive(true);
                break;

            case 25:
                emojiIndex = 7;
                foreach (var _introObj in introObj)
                {
                   // _introObj.GetComponent<Animator>().SetTrigger("isIntroFadeOut");
                }
                break;

            case 27:
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

        introTextnum++;
        ShowText(emojiIndex);
    }
}
