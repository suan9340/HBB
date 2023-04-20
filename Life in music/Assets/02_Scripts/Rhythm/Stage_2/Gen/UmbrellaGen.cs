using System.Collections.Generic;
using UnityEngine;

public class UmbrellaGen : MonoBehaviour,IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                     UmbrellaMove.Add(UmbrellaMove.Direction.left);
                }
                if (i == 1)
                {
                 

                }
                
            }
        }
    }
}
