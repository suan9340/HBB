using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerMove : MonoBehaviour
{
    public static void Add()
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Locker)(Clone)");
        }

        var _obj = Resources.Load<LockerMove>("Notes/Stage_02/LockerNote");

        if (_obj != null)
        {
            //var _inst = Instantiate(_obj, mom.transform.GetChild(0), false);


        }
    }

    private static GameObject mom;
    
    public static bool isFirst = true;

    private void Start()
    {
        //StartCoroutine(a());
    }

    private void OpenDoor()
    {

    }

    private void AddList(GameObject _obj)
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            isFirst = false;
        }

        EventManager<GameObject>.TriggerEvent(ConstantManager.LOCKER_ADD, _obj);
    }

    public void LockerUP()
    {
        Debug.Log("LockerRemove");
    }
}
