using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    private SortingGroup sortingGroup;
    private Animator myAnim;

    private void Start()
    {
        rightPos = defaultVec;


        sortingGroup = GetComponent<SortingGroup>();
        myAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, rightPos) < 0.5f)
        {
            if (!isSelected)
            {
                if (inRightPos == false)
                {
                    transform.position = rightPos;
                    myAnim.SetTrigger("isCorrect");

                    inRightPos = true;
                    sortingGroup.sortingOrder = 0;
                }
            }
        }
    }

    public void OnClickPuzzle(int _OIL)
    {
        myAnim.SetTrigger("isBig");
        isSelected = true;
        sortingGroup.sortingOrder = _OIL;
    }

    public void OnUpPuzzle()
    {
        myAnim.SetTrigger("isSmall");
        isSelected = false;
    }
}
