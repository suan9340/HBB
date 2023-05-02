using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomStickGen : MonoBehaviour,IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                    BroomStickMove.Add();
                }
                if (i == 1)
                {
                }
                if (i == 2)
                {
                }
                if (i == 3)
                {
                }
            }
        }
    }
}
