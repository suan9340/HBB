using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {

                    RockMove.Add(false);

                }
                if (i == 1)
                {

                    RockMove.Add(true);
                }
            }
        }
    }
}

