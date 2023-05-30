using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoSingleTon<MenuManager>
{
    public DefineManager.MenuState menuState;

    [Space(20)]
    public GameObject lockMessageUIObject = null;

    public void ChangeMenuState(DefineManager.MenuState _state)
    {
        menuState = _state;
    }

    public void ShowOrHideLockMessage(bool _isOn)
    {
        if (lockMessageUIObject == null)
        {
            Debug.LogError("lockMessageUI is NULL!!!");
            return;
        }

        if (_isOn)
        {
            ChangeMenuState(DefineManager.MenuState.Clicking);
            lockMessageUIObject.SetActive(true);
        }
        else
        {
            ChangeMenuState(DefineManager.MenuState.Playing);
            lockMessageUIObject?.SetActive(false);
        }
    }
}
