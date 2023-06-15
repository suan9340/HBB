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

    [Space(20)]
    public List<string> puzzleEndTxt = new List<string>();

    public int curNum = -1;


    public DefineManager.PuzzleState GetPuzzleState()
    {
        return puzzleState;
    }

    public void SettingPuzzleState(DefineManager.PuzzleState _puzzleState)
    {
        puzzleState = _puzzleState;
    }

    public void PuzzleCorrect()
    {
        if (curNum >= puzzleEndTxt.Count - 1)
        {
            Debug.Log("end");
            return;
        }
        else
        {
            curNum++;
            SettingPuzzleState(DefineManager.PuzzleState.CanClick);
            PuzzleText.Instance.TextingOut(puzzleEndTxt[curNum]);
        }
    }

    public void CanClickPuzzles()
    {
        SettingPuzzleState(DefineManager.PuzzleState.CanClick);
    }
}
