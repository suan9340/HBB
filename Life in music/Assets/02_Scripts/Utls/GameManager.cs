using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleTon<GameManager>
{
    public DefineManager.GameState gameState;
    public CurrnetstageSO currentStage;
    public bool canClick = false;

    private void Start()
    {
        SettingSO();
    }

    private void SettingSO()
    {
        if (currentStage == null)
        {
            currentStage = Resources.Load<CurrnetstageSO>("SO/CurrentstageSO");
        }
    }

    public DefineManager.StageNames GetCurrentStage()
    {
        return currentStage.stageName;
    }

    public void SettingGameState(DefineManager.GameState _gameState)
    {
        gameState = _gameState;
    }

    public DefineManager.GameState GetGameState()
    {
        return gameState;
    }

    public void SettingCurrentStage(DefineManager.StageNames _stage)
    {
        currentStage.stageName = _stage;
    }

    public void SetClip(AudioClip _clip)
    {
        currentStage.clip = _clip;
    }
}
