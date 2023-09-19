using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureController : MonoBehaviour
{
    public int sceneNum = 0;

    [Space(20)]
    [Header("-- Objects --")]
    public GameObject lockObj = null;
    public StageClearCheck stageClearCheckSo = null;


    [Space(20)]
    [Header("-- UI --")]
    public GameObject stageSulmungUI = null;

    [Space(20)]
    public GameObject lockMessageUIObject = null;

    [Space(20)]
    public AudioSource mysource = null;
    public AudioClip myClip = null;

    private int stage01Check = 0;
    private string sceneName;
    private bool isStage = false;

    private void Start()
    {
        stage01Check = PlayerPrefs.GetInt("Stage01Check");

        CashingObj();
        CheckLockStage();
    }

    private void OnMouseDown()
    {
        if (isStage == false)
        {
            ShowOrHideLockMessages(true);
            Invoke(nameof(ResetLockMessage), 2f);

            return;
        }

        mysource.PlayOneShot(myClip);
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        stageSulmungUI.SetActive(true);
    }

    public void OnclickStages()
    {
        mysource.PlayOneShot(myClip);
        switch (sceneNum)
        {
            case 1:

                //if (stage01Check == 0)
                //{
                //    sceneName = "FirstTuto";
                //}
                //else if (stage01Check == 1)
                //{
                //    sceneName = "Stage_01";
                //}

                sceneName = "FirstTuto";
                break;

            case 2:
                sceneName = "Stage_02";
                break;

            case 3:

                return;

        }


        SceneManager.LoadScene(sceneName);
    }

    public void OnclickOutStageUI()
    {
        mysource.PlayOneShot(myClip);
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
        stageSulmungUI.SetActive(false);
    }

    private void CashingObj()
    {
        if (stageClearCheckSo == null)
        {
            stageClearCheckSo = Resources.Load<StageClearCheck>("SO/StageCheck/StageClearCheckSo");
        }
    }


    private void CheckLockStage()
    {
        if (lockObj == null)
        {
            Debug.LogError("lockObj is NULL!!");
            return;
        }

        var _a = PlayerPrefs.GetInt(ConstantManager.STAGE_02_CHECK);
        var _b = PlayerPrefs.GetInt(ConstantManager.STAGE_03_CHECK);


        if (stageClearCheckSo.stageCheckList[sceneNum - 1].stage == true)
        {
            isStage = true;
            lockObj.SetActive(false);
        }
        else
        {
            isStage = false;
            lockObj.SetActive(true);
        }

        if (_a == 1 || _b == 1)
        {
            isStage = true;
            lockObj.SetActive(false);
        }
    }


    private void ResetLockMessage()
    {
        ShowOrHideLockMessages(false);
    }

    private void ShowOrHideLockMessages(bool _isOn)
    {
        if (lockMessageUIObject == null)
        {
            Debug.LogError("lockMessageUI is NULL!!!");
            return;
        }

        if (_isOn)
        {
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
            lockMessageUIObject.SetActive(true);
        }
        else
        {
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
            lockMessageUIObject?.SetActive(false);
        }
    }
}
