using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureController : MonoBehaviour
{
    public int sceneNum = 0;
    public CurrnetstageSO currentSO = null;

    private void Start()
    {
        if (currentSO == null)
        {
            Debug.LogError("CurrentSo is NULL");
        }
    }

    private void OnMouseDown()
    {
        switch (sceneNum)
        {
            case 1:
                currentSO.stageName = DefineManager.StageNames.Sea_01;
                break;

            case 2:
                currentSO.stageName = DefineManager.StageNames.School_02;
                break;
        }
        SceneManager.LoadScene(sceneNum);
    }
}
