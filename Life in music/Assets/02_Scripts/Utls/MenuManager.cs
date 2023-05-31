using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoSingleTon<MenuManager>
{
    public DefineManager.MenuState menuState;

    public void ChangeMenuState(DefineManager.MenuState _state)
    {
        menuState = _state;
    }
}
