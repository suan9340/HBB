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
    public PuzzleStageEndSO stageEndText = null;

    public int curNum = -1;
    public int curStageEnd = 0;


    [Space(50)]
    public GameObject stage01Puzzle = null;
    public GameObject stage02Puzzle = null;

    private void Awake()
    {
        CheckPuzzle();
        CheckStageSOData();
        curNum = -1;
    }

    private void CheckPuzzle()
    {
        switch (curStageEnd)
        {
            case 1:
                stage01Puzzle.SetActive(true);
                break;


            case 2:
                stage02Puzzle.SetActive(true);
                break;

            default:
                Debug.Log($"Enable!!{curStageEnd}   <- this Stage!!");
                break;
        }
    }

    private void CheckStageSOData()
    {
        if (stageEndText == null)
        {
            Debug.Log("stageEndTextSo is NULL Y Connectingggg....");
            stageEndText = Resources.Load<PuzzleStageEndSO>("SO/PuzzleStageEndSO");
        }
    }

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
        if (curNum >= stageEndText.stagesEndTxt[curStageEnd + 1].stageEndPuzzleList.Count - 1)
        {
            Debug.Log("end");
            return;
        }
        //if (curNum >= puzzleEndTxt.Count - 1)
        //{
        //    Debug.Log("end");
        //    return;
        //}
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
