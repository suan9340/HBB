using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConchGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                    ConchMove.ConchAdd(ConchMove.ConchDirection.one);
                }
                if (i == 1)
                {
                    ConchMove.ConchAdd(ConchMove.ConchDirection.two);
                }
                if (i == 2)
                {
                    ConchMove.ConchAdd(ConchMove.ConchDirection.three);
                }
             
            }
        }
    }
}
