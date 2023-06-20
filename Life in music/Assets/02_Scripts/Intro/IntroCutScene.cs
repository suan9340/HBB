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



    [Space(20)]
    public int introTextnum = 0;
    public int introObjNum = 0;


    private void Start()
    {
        ShowText();
        ShowIntroObj();
    }


    private void FadeInIntroObj(GameObject _obj)
    {
        if (_obj == null)
        {
            Debug.LogError("Obj is NULL!!");
            return;
        }

        _obj.SetActive(true);
        _obj.GetComponent<Animator>().SetTrigger("isIntroFadeIn");
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
                FadeInIntroObj(introObj[1]);
                break;

            default:
                break;
        }

        introTextnum++;
        ShowText();
    }
}
