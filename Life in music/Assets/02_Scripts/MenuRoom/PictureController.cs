using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureController : MonoBehaviour
{
    public int sceneNum = 0;
    public CurrnetstageSO currentSO = null;

    [Space(20)]
    [Header("-- Objects --")]
    public GameObject lockObj = null;
    public StageClearCheck stageClearCheckSo = null;


    [Space(20)]
    [Header("-- UI --")]
    public GameObject stageSulmungUI = null;

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
            MenuManager.Instance.ShowOrHideLockMessage(true);
            Invoke(nameof(ResetLockMessage), 2f);

            return;
        }

        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        stageSulmungUI.SetActive(true);
    }

    public void OnclickStages()
    {
        //if (isStage == false)
        //{
        //    MenuManager.Instance.ShowOrHideLockMessage(true);
        //    Invoke(nameof(ResetLockMessage), 2f);

        //    return;
        //}

        switch (sceneNum)
        {
            case 1:

                currentSO.stageName = DefineManager.StageNames.Sea_01;

                if (stage01Check == 0)
                {
                    sceneName = "FirstTuto";
                }
                else if (stage01Check == 1)
                {
                    sceneName = "Stage_01";
                }

                break;

            case 2:
                currentSO.stageName = DefineManager.StageNames.School_02;
                sceneName = "Stage_02";
                break;
        }


        SceneManager.LoadScene(sceneName);
    }

    public void OnclickOutStageUI()
    {
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
        stageSulmungUI.SetActive(false);
    }

    private void CashingObj()
    {
        if (currentSO == null)
        {
            Debug.LogError("CurrentSo is NULL");
        }

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
    }


    private void ResetLockMessage()
    {
        MenuManager.Instance.ShowOrHideLockMessage(false);
    }
}
