using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellGen : MonoBehaviour, IGen
{
    private float pos = 100f;
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(pos);
            if (list[i])
            {
                if (i == 0)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.left, pos);

                }
                if (i == 1)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.right, pos);

                }
                if (i == 2)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.down, pos);

                }
                if (i == 3)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.up, pos);

                }
                pos -= 20f;
            }
        }
    }

}
