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
                if (i == 0)
                {
                    BellMove.BellAdd(BellMove.BellPos.Left);
                }
                if (i == 1)
                {
                    BellMove.BellAdd(BellMove.BellPos.Mid);
                }
                if (i == 2)
                {
                    BellMove.BellAdd(BellMove.BellPos.Right );
                }
                if (i == 3)
                {
                    EventManager.TriggerEvent(ConstantManager.NOTE_IMAGE_INSTANCE);
                }
            }
        }
    }
}
