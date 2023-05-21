using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int checkFirst;

    private void Start()
    {
        checkFirst = PlayerPrefs.GetInt("CheckFirst");
    }

    public void OnClickStart()
    {
        if (checkFirst == 0)        // First Game
        {
            SceneManager.LoadScene("StoryRoom");
        }
        else if (checkFirst == 1)
        {
            SceneManager.LoadScene("Room");
        }

        Debug.Log(checkFirst);
    }

    public void OnClickOut()
    {
        Application.Quit();
    }
}
