using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                EventManager.TriggerEvent(ConstantManager.NOTE_IMAGE_INSTANCE);
            }
        }
    }
}
