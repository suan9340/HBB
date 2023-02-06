using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFishRhythm : MonoBehaviour
{
    public GameObject shellfishOpen = null;
    public GameObject shellfishClose = null;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnCLickShellScreen();
        }
    }
    public void OnCLickShellScreen()
    {
        if (shellfishOpen == null)
        {
            Debug.LogError("ShellfishOpen is null!!");
            return;
        }
        else
        {
            if (shellfishOpen.activeSelf)
            {
                shellfishOpen.SetActive(false);
            }
            else
            {
                shellfishOpen.SetActive(true);
            }
        }
    }
}
