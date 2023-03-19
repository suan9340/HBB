using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [Header("GameOutUI")]
    public Animator GameOutAnim = null;
    private bool isOut = false;
    public void OnClickDoorExit()
    {
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
            GameOutAnim.SetBool("isGameOut", true);
        }
        else
        {
            GameOutAnim.SetBool("isGameOut", false);
        }
    }

}
