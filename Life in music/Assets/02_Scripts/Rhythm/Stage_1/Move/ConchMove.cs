using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ConchMove : MonoBehaviour
{
    public static void Add(bool _isLeft)
    {

    }

    public static void Remove()
    {

    }

    public bool isFirst = false;

    private void Start()
    {

    }

    private void Cashing()
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

        EventManager<GameObject>.TriggerEvent(ConstantManager.CONCHLIST_ADD, _obj);
    }



}
