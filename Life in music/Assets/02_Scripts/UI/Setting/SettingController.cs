using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingController : MonoBehaviour
{
    [Header("SettingChang")]
    public GameObject settingObj = null;


    [Space(20)]
    [Header("Animator")]
    public Animator myAnim = null;

    private bool isSettingOn = false;
    private bool isSettingChanging = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickSetting();
        }
    }

    public void OnClickSetting()
    {
        if (isSettingChanging)
        {
            return;
        }

        isSettingOn = !isSettingOn;
        isSettingChanging = true;

        if (isSettingOn)
        {
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
            //Debug.Log("isSetting");
            myAnim.SetTrigger("SettingOn");
        }
        else
        {
            //Debug.Log("SettingEnd");
            myAnim.SetTrigger("SettingOff");
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
        }

        Invoke(nameof(ResetSettincChanging), 1.5f);
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ResetSettincChanging()
    {
        isSettingChanging = false;
    }

}
