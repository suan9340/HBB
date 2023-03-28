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

        EventManager.StartListening(ConstantManager.STARFISH_ANIM, StarfishDown);
    }

    private void AddList(GameObject _obj)
    {
        if (Starfish_isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            Starfish_isFirst = false;
        }


        EventManager<GameObject>.TriggerEvent(ConstantManager.STARFISH_ADD, _obj);
    }

    public void StarfishDown()
    {
        myanim.SetTrigger("isStarfishClick");
        AddList(gameObject);
    }
}
