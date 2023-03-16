using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StarFishMove : MonoBehaviour
{
    private static GameObject mom;
    public static float _spos = -220f;

    public static bool Starfish_isFirst = true;

    public static void StarFishAdd()
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Starfish)(Clone)");
        }

        var _obj = Resources.Load<StarFishMove>("Notes/Stage_01/StarfishNote");


        if (_obj != null)
        {
            //애니메이션을 실행해야한다.
        }

        else
        {
            Debug.LogError("ShellfishNote NULL");
        }
    }

    


    public static void Remove()
    {
        // 자동삭제
    }

    private Animator myanim = null;
    private RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        myanim = GetComponent<Animator>();

        MoveStarFish();
        EventManager.StartListening(ConstantManager.STARFISH_ANIM, StarfishAnim);
    }

    private void MoveStarFish()
    {
       AddList(gameObject);
    }

    private void AddList(GameObject _obj)
    {

        if (Starfish_isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            Starfish_isFirst = false;
        }

    
        EventManager<GameObject>.TriggerEvent(ConstantManager.STARFISH_ADD, _obj);
    }

    public void StarfishDown()
    {
        myanim.SetTrigger("isStarfishClick");
    }

    public void StarfishAnim()
    {
        //Debug.Log("애니메이션");
          StarfishDown();

    }
}
