using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWeedGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                    SeaWeedMove.Add(SeaWeedMove.SeaWeedPos.one);
                }

                if (i == 1)
                {
                    SeaWeedMove.Add(SeaWeedMove.SeaWeedPos.two);
                }

                if (i == 2)
                {
                    SeaWeedMove.Add(SeaWeedMove.SeaWeedPos.three);
                }
                if (i == 3)
                {
                    EventManager.TriggerEvent(ConstantManager.NOTE_IMAGE_INSTANCE);
                }
            }
        }
    }
}
