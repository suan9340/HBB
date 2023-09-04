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

    public AudioSource mySource = null;
    public AudioClip btnClickClip = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.gameState != DefineManager.GameState.Rhythm)
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

        mySource.PlayOneShot(btnClickClip);
        isSettingOn = !isSettingOn;
        isSettingChanging = true;

        if (isSettingOn)
        {
            GameManager.Instance.gameState = DefineManager.GameState.CantClick;
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
            myAnim.SetTrigger("SettingOn");
        }
        else
        {
            GameManager.Instance.gameState = DefineManager.GameState.Playing;
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
            myAnim.SetTrigger("SettingOff");
        }

        Invoke(nameof(ResetSettincChanging), 1f);
    }

    public void OnClickMenu()
    {
        GameManager.Instance.gameState = DefineManager.GameState.Playing;
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
        SceneManager.LoadScene("Room");
    }

    private void ResetSettincChanging()
    {
        isSettingChanging = false;
    }

}
