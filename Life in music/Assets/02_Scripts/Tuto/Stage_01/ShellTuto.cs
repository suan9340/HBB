using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTuto : TutoMOM
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isClick) return;

            isClick = true;
            myAnim.SetTrigger("isDown");
            mySource.PlayOneShot(myClip);
        }
    }

}
