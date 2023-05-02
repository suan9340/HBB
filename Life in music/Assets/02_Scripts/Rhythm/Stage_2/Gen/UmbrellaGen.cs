using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaGen : MonoBehaviour,IGen
{
    private void Start()
    {
      
    }

    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                     UmbrellaMove.Add(UmbrellaMove.State.Move);
                }
                if (i == 1)
                {
                 

                }
                
            }
        }
    }
}
