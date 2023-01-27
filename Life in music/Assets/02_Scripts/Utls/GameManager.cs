using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    public DefineManager.GameState gameState;

    public void SettingGameState(DefineManager.GameState _gameState)
    {
        gameState = _gameState;
    }
}
