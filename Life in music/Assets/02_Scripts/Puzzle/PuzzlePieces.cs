using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class PuzzlePieces : MonoBehaviour
{
    private Vector3 rightPos = Vector3.zero;


    public bool inRightPos = false;
    public bool isSelected = false;

    [Space(20)]
    [Header("Puzzle Default Position")]
    public Vector3 defaultVec = Vector3.zero;

    [Space(20)]
    [Header("Puzzle Big Y Small Size")]
    public Vector3 smallVec = Vector3.zero;
    public Vector3 bigVec = Vector3.zero;

    public float puzzleMoveSpeed = 1f;

    private Vector3 lastPos = Vector3.zero;

    private SortingGroup sortingGroup;
    private Animator myAnim;

    private void Start()
    {
        rightPos = defaultVec;


        sortingGroup = GetComponent<SortingGroup>();
        myAnim = GetComponent<Animator>();
    }


    public void OnClickPuzzle(int _OIL)
    {
        PuzzleManager.Instance.SettingPuzzleState(DefineManager.PuzzleState.CantClick);
        lastPos = transform.position;

        myAnim.SetTrigger("isBig");
        isSelected = true;
        sortingGroup.sortingOrder = _OIL;
    }

    public void OnUpPuzzle()
    {
        myAnim.SetTrigger("isSmall");
        isSelected = false;
    }

    public void PuzzleRight()
    {
        if (Vector3.Distance(transform.position, rightPos) < 0.5f)
        {
            if (!isSelected)
            {
                if (inRightPos == false)
                {
                    PuzzleManager.Instance.PuzzleCorrect();
                    
                    transform.position = rightPos;

                    inRightPos = true;
                    sortingGroup.sortingOrder = 0;

                    myAnim.SetTrigger("isCorrect");
                    ParticleManager.Instance.AddParticle(ParticleManager.ParticleType.puzzleEffect, transform.position);
                }

            }
        }
        else
        {
            transform.DOMove(lastPos, puzzleMoveSpeed);
        }

    }
}
