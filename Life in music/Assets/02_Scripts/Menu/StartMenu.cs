using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int checkFirst;
    public AudioSource mySource = null;
    public AudioClip btnClickClip = null;

    private void OnEnable()
    {
        PlayerPrefs.DeleteAll();
    }
    private void Start()
    {
        //checkFirst = PlayerPrefs.GetInt("CheckFirst");
    }

    public void OnClickStart()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.DeleteKey(ConstantManager.STAGE_02_CHECK);
        //PlayerPrefs.DeleteKey(ConstantManager.STAGE_03_CHECK);

        mySource.PlayOneShot(btnClickClip);
        SceneManager.LoadScene("StoryRoom");

        //if (checkFirst == 0)        // First Game
        //{
        //}
        //else if (checkFirst == 1)
        //{
        //    SceneManager.LoadScene("Room");
        //}

        //Debug.Log(checkFirst);
    }

    public void OnClickOut()
    {
        mySource.PlayOneShot(btnClickClip);
        Application.Quit();
    }

    public void OnClickReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
