using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public PuzzleStageEndSO stageEndText = null;

    public int curNum = -1;
    private int curStageEnd = 0;

    private int puzzleMaxCnt = 0;
    private int puzzlecurCnt = 0;

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
        curStageEnd = PlayerPrefs.GetInt(ConstantManager.STAGE_END_Y_CHECKINGPUZLLE);

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

        puzzleMaxCnt = stageEndText.stagesEndTxt[curStageEnd - 1].stageEndPuzzleList.Count;
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
        curNum++;
        puzzlecurCnt++;
        var _input = stageEndText.stagesEndTxt[curStageEnd - 1].stageEndPuzzleList[curNum];

        SettingPuzzleState(DefineManager.PuzzleState.CanClick);
        PuzzleText.Instance.TextingOut(_input);
        //Debug.Log($"{puzzlecurCnt}   /    {puzzleMaxCnt}");
    }

    public void CanClickPuzzles()
    {
        if (puzzlecurCnt == puzzleMaxCnt)
        {
            Debug.Log("end");
            SceneManager.LoadScene("Room");
        }
        else
        {
            SettingPuzzleState(DefineManager.PuzzleState.CanClick);
        }
    }
}
