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


    [Space(20)]
    public AudioSource audioSorce = null;
    public AudioClip openDoorclip = null;
    public AudioClip closeeDoorclip = null;
    private void Start()
    {
        EventManager.StartListening(ConstantManager.CLOSE_DOOR, CheckDoor);
    }
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
        //if (isDoorOn || isDoorOpening)
        //    return;

        if (isDoorOn)
        {
            return;
        }

        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
        {
            return;
        }

        audioSorce.PlayOneShot(openDoorclip);
        CheckDoor();

        isDoorOn = true;
        isDoorOpening = true;

        openDoor.SetActive(true);
        closeDoor.SetActive(false);

        Debug.Log("Eixt Game");
    }

    private void OnDoorMouseDown()
    {
        if (isDoorOn)
        {
            gameQuestObj.SetActive(true);
            MenuManager.Instance.ChangeMenuState(DefineManager.MenuState.Clicking);
        }
    }

    private void OnDoorMouseExit()
    {
        if (MenuManager.Instance.menuState == DefineManager.MenuState.Clicking)
            return;

        CheckDoor();
    }

    private void CheckDoor()
    {
        isDoorOn = false;
        isDoorOpening = false;
        audioSorce.PlayOneShot(closeeDoorclip);

        openDoor.SetActive(false);
        closeDoor.SetActive(true);
    }
}
