using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isDoorOn = false;
    private bool isDoorOpening = false;

    public GameObject openDoor = null;
    public GameObject closeDoor = null;

    [Space(20)]
    public GameObject gameQuestObj = null;

    private void OnMouseOver()
    {
        OnDoorMouseUP();
    }
    private void OnMouseDown()
    {
        OnDoorMouseDown();
    }
    private void OnMouseExit()
    {
        OnDoorMouseExit();
    }


    private void OnDoorMouseUP()
    {
        if (isDoorOn || isDoorOpening)
            return;

        isDoorOn = true;
        isDoorOpening = true;

        openDoor.SetActive(true);
        closeDoor.SetActive(false);
        gameQuestObj.SetActive(true);
        Debug.Log("Eixt Game");
    }

    private void OnDoorMouseDown()
    {

    }

    private void OnDoorMouseExit()
    {
        isDoorOn = false;
        isDoorOpening = false;

        openDoor.SetActive(false);
        closeDoor.SetActive(true);
    }
}
