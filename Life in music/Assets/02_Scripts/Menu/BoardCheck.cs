using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardCheck : MonoBehaviour
{
    public void OnClickCheckStage(int num)
    {
        Debug.Log("SceneLoad");
        SceneManager.LoadScene(num);
    }
}
