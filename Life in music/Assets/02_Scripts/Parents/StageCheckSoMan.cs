using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCheckSoMan : MonoBehaviour
{
    public CurrnetstageSO currentSO = null;
    public int stageNum = 0;

    public void Awake()
    {
        if (currentSO == null)
        {
            Debug.LogError("CurrentStage is NULL!!");
        }

        switch (stageNum)
        {
            case 1:
                currentSO.stageName = DefineManager.StageNames.Sea_01;
                break;

            case 2:
                currentSO.stageName = DefineManager.StageNames.School_02;
                break;

        }
    }



}
