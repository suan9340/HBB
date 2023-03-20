using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [Header("GameOutUI")]
    public Animator GameOutAnim = null;
    public List<GameObject> doors = new List<GameObject>();
    private bool isOut = false;


    [Space(20)]
    [Header("BoardUI")]
    public Animator BoardAnim = null;
    private bool isBoardZoomIn = false;

    #region GameOutUI
    public void OnClickDoorExit()
    {
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
            GameManager.Instance.SettingGameState(DefineManager.GameState.Menu);

            GameOutAnim.SetBool("isGameOut", false);

            doors[0].SetActive(false);
            doors[1].SetActive(false);
        }
    }
    #endregion


    public void OnClickBoard()
    {
        BoardUI();
    }
    private void BoardUI()
    {
        isBoardZoomIn = !isBoardZoomIn;

        if (isBoardZoomIn)
        {
            GameManager.Instance.SettingGameState(DefineManager.GameState.Menu_Set);
            BoardAnim.SetBool("isBoardClick", true);

        }
        else
        {
            GameManager.Instance.SettingGameState(DefineManager.GameState.Menu);
            BoardAnim.SetBool("isBoardClick", false);
        }
    }
}
