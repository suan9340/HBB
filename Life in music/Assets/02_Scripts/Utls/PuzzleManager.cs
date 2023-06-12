using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    #region SingleTon

    private static PuzzleManager _instance = null;
    public static PuzzleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PuzzleManager>();
                if (_instance == null)
                {
                    _instance = new GameObject("PuzzleManager").AddComponent<PuzzleManager>();
                }
            }
            return _instance;
        }
    }

    #endregion

    public DefineManager.PuzzleState puzzleState;

    public DefineManager.PuzzleState GetPuzzleState()
    {
        return puzzleState;
    }

    public void SettingPuzzleState(DefineManager.PuzzleState _puzzleState)
    {
        puzzleState = _puzzleState;
    }
}
