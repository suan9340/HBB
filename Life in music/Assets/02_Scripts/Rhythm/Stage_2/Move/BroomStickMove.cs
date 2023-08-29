
using UnityEngine;

public class BroomStickMove : MonoBehaviour
{
    private static GameObject mom;
    public static bool isFirst = true;

    public static void Add()
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (BroomStick)(Clone)");
        }

        var _obj = Resources.Load<BroomStickMove>("Notes/Stage_02/BroomStickNote");
        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);
        }
    }

    public static void Remove()
    {
        // 자동삭제
    }

    private Animator myAnim;


    private void Start()
    {
        myAnim = GetComponent<Animator>();

        AddList(gameObject);
    }

    private void AddList(GameObject _obj)
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            isFirst = false;
        }

        EventManager<GameObject>.TriggerEvent(ConstantManager.BROOMSTICK_ADD, _obj);
        myAnim.SetTrigger("BroomStickShow");
    }

    public void BroomStickDown()
    {
        myAnim.SetTrigger("BroomStickClick");
        BroomStickDestroy();
        //  Invoke("BroomStickDestroy",1.2f);
    }

    public void BroomStickDestroy()
    {
        Destroy(gameObject);
    }
}
