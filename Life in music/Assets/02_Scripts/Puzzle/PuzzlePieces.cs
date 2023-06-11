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
    public Vector3 defaultVec = Vector3.zero;

    private void Start()
    {
        rightPos = defaultVec;


        transform.position = new Vector3(Random.Range(11f, 17f), Random.Range(8f, -8f));
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
                    inRightPos = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
}
