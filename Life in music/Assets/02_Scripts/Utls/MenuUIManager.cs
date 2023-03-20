using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [Header("GameOutUI")]
    public Animator GameOutAnim = null;
    public List<GameObject> doors = new List<GameObject>();
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

            doors[0].SetActive(true);
            doors[1].SetActive(true);
        }
        else
        {
            GameOutAnim.SetBool("isGameOut", false);



            doors[0].SetActive(false);
            doors[1].SetActive(false);
        }
    }

}
