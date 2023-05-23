using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureController : MonoBehaviour
{
    public int sceneNum = 0;
    public CurrnetstageSO currentSO = null;

    private int stage01Check = 0;
    private string sceneName;

    private void Start()
    {
        stage01Check = PlayerPrefs.GetInt("Stage01Check");

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

                if (stage01Check == 0)
                {
                    sceneName = "FirstTuto";
                }
                else if (stage01Check == 1)
                {
                    sceneName = "Stage_01";
                }

                break;

            case 2:
                currentSO.stageName = DefineManager.StageNames.School_02;
                sceneName = "Stage_02";
                break;
        }


        SceneManager.LoadScene(sceneName);
    }
}
