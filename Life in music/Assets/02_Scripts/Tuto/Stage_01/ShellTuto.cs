using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTuto : TutoMOM
{
    protected override void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isClick) return;

            isClick = true;
            myAnim.SetTrigger("isDown");
            mySource.PlayOneShot(myClip);
        }
    }

}
