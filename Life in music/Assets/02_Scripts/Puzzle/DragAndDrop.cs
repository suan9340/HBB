using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject selectObj = null;
    private RaycastHit hit;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if(Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector3.zero))
        //    {

        //    }
        //    RaycastHit hit = Physics2.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //    {
        //        if (hit.transform.CompareTag("Puzzle"))
        //        {
        //            selectObj = hit.transform.gameObject;
        //        }
        //    }
        //}

        //if (selectObj != null)
        //{
        //    selectObj.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}

        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out hit))
            //{
            //    Debug.Log(hit.transform);
            //}

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.red;

        bool ishit = Physics.Raycast(transform.position, transform.forward, out hit, 100f);
        if (ishit)
        {
            Debug.Log("qwe");
            Gizmos.DrawRay(transform.position, transform.forward * 100f);
        }
    }
}
