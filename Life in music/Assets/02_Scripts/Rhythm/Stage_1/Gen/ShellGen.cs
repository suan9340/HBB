using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.left);


                }
                if (i == 1)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.right);

                }
                if (i == 2)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.down);

                }
                if (i == 3)
                {
                    ShellfishMove.Add(ShellfishMove.Direction.up);

                }
                if (i == 4)
                {
                    EventManager.TriggerEvent(ConstantManager.NOTE_IMAGE_INSTANCE);
                }

            }
        }
    }

}
