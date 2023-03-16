using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class ConchMove : MonoBehaviour
{

    public static bool conchMove_isFirst = true;

    public Image musicNote;

    private static GameObject conchMom;

    public static void Add()
    {
         if (conchMom == null)
        {
           conchMom = GameObject.Find("Rhythm (Conch)(Clone)");
        }

        var _conchobj = Resources.Load<ConchMove>("Notes/Stage_01/ConchNote");

        if (_conchobj != null)
        {
            var _conchInst = Instantiate(_conchobj, conchMom.transform, false);
            _conchInst.transform.localPosition = new Vector3(1100f, 500f, 0f);
        }

    
    }

    public static void Remove()
    {

    }

    public bool isFirst = false;

    private void Start()
    {
        MoveConch();
    }

    private void Update()
    {
      
    }
    

    private void MoveConch()
    {
        AddList(gameObject);
    }

    private void AddList(GameObject _obj)
        {
        if (conchMove_isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            conchMove_isFirst = false;
        }
       
           EventManager<GameObject>.TriggerEvent(ConstantManager.CONCHLIST_ADD, _obj);
    }
}
