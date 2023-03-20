using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("GameOutUI")]
    public Animator GameOutAnim = null;
    public List<GameObject> doors = new List<GameObject>();
    private bool isOut = false;
    private DefineManager.GameState lastState;


    [Space(20)]
    [Header("BoardUI")]
    public Animator BoardAnim = null;
    public List<GameObject> stageBtn = new List<GameObject>();


    [Space(20)]
    [Header("StartUI")]
    public Animator startAnim = null;


    private bool isBoardZoomIn = false;
    private bool isMoving = false;
    private readonly WaitForSeconds boardSec = new WaitForSeconds(1.5f);

    #region GameOutUI
    public void OnClickDoorExit()
    {
        lastState = GameManager.Instance.GetGameState();

        if (GameManager.Instance.GetGameState() == DefineManager.GameState.Menu_Set)
        {
            return;
        }

        OutUI();
    }

    public void OnClickReallyOut()
    {
        Debug.Log("Out Game");
    }

    public void OnClickReallyNoOut()
    {
        Debug.Log("No out");
        OutUI();


    }

    public void OutUI()
    {
        if (GameOutAnim == null)
        {
            Debug.LogError("GameOutAnim is NULL!!!!");
            return;
        }


        isOut = !isOut;

        if (isOut)
        {
            GameManager.Instance.SettingGameState(DefineManager.GameState.Menu_Set);

            GameOutAnim.SetBool("isGameOut", true);

            doors[0].SetActive(true);
            doors[1].SetActive(true);
        }
        else
        {
            GameManager.Instance.SettingGameState(lastState);

            GameOutAnim.SetBool("isGameOut", false);

            doors[0].SetActive(false);
            doors[1].SetActive(false);
        }
    }
    #endregion


    public void OnClickBoard()
    {
        if (GameManager.Instance.GetGameState() == DefineManager.GameState.Start)
        {
            return;
        }

        StartCoroutine(BoardUI());
    }

    private IEnumerator BoardUI()
    {
        if (isMoving)
        {
            yield break;
        }

        isBoardZoomIn = !isBoardZoomIn;
        isMoving = true;

        if (isBoardZoomIn)
        {
            BoardAnim.SetBool("isBoardClick", true);
            GameManager.Instance.SettingGameState(DefineManager.GameState.Menu_Set);

            yield return boardSec;
            isMoving = false;
            SettingStageBtn(true);
        }
        else
        {
            BoardAnim.SetBool("isBoardClick", false);
            SettingStageBtn(false);


            yield return boardSec;
            GameManager.Instance.SettingGameState(DefineManager.GameState.Menu);
            isMoving = false;
        }

        yield return null;
    }

    public void OnClickStage()
    {
        SceneManager.LoadScene(1);
    }

    private void SettingStageBtn(bool _isOn)
    {
        var _listCnt = stageBtn.Count;
        if (_listCnt == 0)
        {
            Debug.Log("stageBtn is NULL!!!");
            return;
        }

        for (int i = 0; i < _listCnt; i++)
        {
            stageBtn[i].SetActive(_isOn);
        }
    }

    public void OnClickStart()
    {
        startAnim.SetTrigger("isClickStartBtn");
        GameManager.Instance.SettingGameState(DefineManager.GameState.Menu);
    }
}
