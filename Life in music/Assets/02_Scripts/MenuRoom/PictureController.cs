using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PictureController : MonoBehaviour
{
    public int sceneNum = 0;

    private void OnMouseDown()
    {
        Debug.Log(sceneNum);
        SceneManager.LoadScene(sceneNum);
    }
}
