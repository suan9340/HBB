using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectObj = null;
    int OIL = 1;

    private RaycastHit hit;
    private Vector3 mousePos = Vector3.zero;
    private Camera maincam;

    private void Start()
    {
        maincam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos = maincam.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, 15f);
            Debug.DrawRay(mousePos, transform.forward * 15f, Color.red);

            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PuzzlePieces>().inRightPos)
                {
                    selectObj = hit.transform.gameObject;
                    selectObj.GetComponent<PuzzlePieces>().isSelected = true;
                    selectObj.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectObj != null)
            {
                selectObj.GetComponent<PuzzlePieces>().isSelected = false;
                selectObj = null;
            }
        }

        if (selectObj != null)
        {
            Vector3 _mousePosition = maincam.ScreenToWorldPoint(Input.mousePosition);
            selectObj.transform.position = new Vector3(_mousePosition.x, _mousePosition.y, 0f);
        }
    }

}