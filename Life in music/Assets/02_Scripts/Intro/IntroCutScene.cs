using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    [Space(20)]
    public List<GameObject> introObj = new List<GameObject>();
    public GameObject IntroObj = null;

    [Space(20)]
    public List<AudioClip> introClip = new List<AudioClip>();
    public AudioSource mySource = null;

    [Space(20)]
    public int introTextnum = 0;
    public int introObjNum = 0;


    private void Start()
    {
        ShowText();
        ShowIntroObj();
        mySource.PlayOneShot(introClip[0]);
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
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

    public void CheckNum()
    {
        switch (introTextnum)
        {
            case 1:
                mySource.Stop();
                break;

            case 2:
                FadeInIntroObj(introObj[1]);
                break;

            case 4:
                mySource.PlayOneShot(introClip[1]);
                break;

            case 6:
                FadeInIntroObj(introObj[2]);
                break;

            case 10:
                FadeInIntroObj(introObj[3]);
                break;

            case 14:
                foreach (var _introOb in introObj)
                {
                    _introOb.GetComponent<Animator>().SetTrigger("isIntroFadeOut");
                }

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
        ShowText();
    }
}
