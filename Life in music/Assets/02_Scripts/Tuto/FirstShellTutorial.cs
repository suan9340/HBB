using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FirstShellTutorial : MonoBehaviour
{

    Vector2 rayOrigin = Vector2.zero;
    RaycastHit2D hit;

    public GameObject isFirstTutoObj;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0) && isFirstTutoObj.GetComponent<IsFirstTuto>().isShellTuto)
        {
            rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("¾È³ç");
                isFirstTutoObj.GetComponent<IsFirstTuto>().isShellTuto = false;
            }
        }
    }
}
