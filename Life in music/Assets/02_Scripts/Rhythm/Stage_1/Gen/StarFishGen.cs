using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFishGen : MonoBehaviour, IGen
{
    public void Gen(List<bool> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                if (i == 0)
                {
                    EventManager.TriggerEvent(ConstantManager.STARFISH_ANIM);
                }
                if (i == 1)
                {
                    EventManager.TriggerEvent(ConstantManager.NOTE_IMAGE_INSTANCE);
                }
            }
        }
    }

}
