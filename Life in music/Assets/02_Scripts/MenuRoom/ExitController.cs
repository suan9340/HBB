using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public GameObject exitObj = null;

    public void OnClickNO()
    {
        MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Playing);
        Debug.Log("NO");
        EventManager.TriggerEvent(ConstantManager.CLOSE_DOOR);
        exitObj.SetActive(false);
    }

    public void OnClickYes()
    {
        Debug.Log("YES");
        Application.Quit();
    }
}
