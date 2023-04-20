using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                    LockerMove.Add();
                }
                if (i == 1)
                {
                    EventManager.TriggerEvent(ConstantManager.NOTE_IMAGE_INSTANCE);
                }
            }
        }
    }
}
