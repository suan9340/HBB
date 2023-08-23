using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject selectUI = null;

    [Space(20)]
    public Button selecButton1 = null;
    public Button selecButton2 = null;
    public Button selecButton3 = null;
    public Button selecButton4 = null;
    [Space(20)]

    public Text selecButtonText1 = null;
    public Text selecButtonText2 = null;
    public Text selecButtonText3 = null;
    public Text selecButtonText4 = null;

    public IntroText introTextScript;

    private void Start()
    {
        ShowText();
        ShowIntroObj();
        mySource.PlayOneShot(introClip[0]);
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        PlayerPrefs.SetInt("CheckFirst", 1);
    }

    private void Update()
    {
        switch(introTextnum)
        {
            case 2:
                selecButton1.gameObject.SetActive(true);
                selecButton2.gameObject.SetActive(true);
                selecButton3.gameObject.SetActive(false);
                selecButton4.gameObject.SetActive(false);

                selecButton1.onClick.AddListener(() => AddButtonClickListener(selecButton1, 4));
                selecButton2.onClick.AddListener(() => AddButtonClickListener(selecButton2, 3));
                break;

            case 8:
                selecButton1.gameObject.SetActive(false);
                selecButton2.gameObject.SetActive(false);
                selecButton3.gameObject.SetActive(true);
                selecButton4.gameObject.SetActive(true);

                selecButton3.onClick.AddListener(() => AddButtonClickListener(selecButton3, 9));
                selecButton4.onClick.AddListener(() => AddButtonClickListener(selecButton4, 10));

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

    private void ShowText()
    {
        IntroText.Instance.TextingOut(introText[introTextnum]);
    }

    private void ShowIntroObj()
    {
        FadeInIntroObj(introObj[introObjNum]);
    }

    private void AddButtonClickListener(Button button, int newIntroTextnum)
    {
        button.onClick.AddListener(() =>
        {
            introTextScript.gameObject.GetComponent<IntroText>().isChoice = true;
            CutSceneSelect(false);
            introTextnum = newIntroTextnum;
            CheckNum();
        });
    }

    private void CutSceneSelect(bool setActive)
    {
        selectUI.gameObject.SetActive(setActive);
        introTextScript.gameObject.GetComponent<IntroText>().isChoice = !setActive;
    }

    public void CheckNum()
    {
        switch (introTextnum)
        {
            case 2:
                CutSceneSelect(true);
                selecButtonText1.text = selectText[0];
                selecButtonText2.text = selectText[1];
                break;

            case 4:
                introObj[1].GetComponent<Animator>().SetBool("ReSleep", true);
                mySource.Stop();
                break;

            case 5:
                introObj[1].GetComponent<Animator>().SetBool("ReSleep", false);
                FadeInIntroObj(introObj[2]);
                break;

            case 8:
                CutSceneSelect(true);
                selecButtonText3.text = selectText[2];
                selecButtonText4.text = selectText[3];
                break;

            case 9:
                introTextnum++;
                break;

            case 11:
                Debug.Log("11");
                break;

            case 12:
                Debug.Log("12");
                break;

            case 13:
                Debug.Log("13");
                break;

            case 14:
                Debug.Log("14");
                //foreach (var _introOb in introObj)
                //{
                //    _introOb.GetComponent<Animator>().SetTrigger("isIntroFadeOut");
                //}

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
        Debug.Log(introTextnum);
        introTextnum++;
        ShowText();
    }
}
