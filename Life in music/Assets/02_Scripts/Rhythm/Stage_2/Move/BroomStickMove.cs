
using UnityEngine;

public class BroomStickMove : MonoBehaviour
{
    private static GameObject mom;
    public static float _spos = -220f;

    public static void BroomStickAdd()
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

    public float moveSpeed = 4f;
    public static bool isFirst = true;

    private Transform myTrn = null;
    private Animator myAnim = null;

    private bool BroomStick_isFirst;

    private void Start()
    {
        myTrn = GetComponent<Transform>();
        myAnim = GetComponentInChildren<Animator>();
    }

    private void BroomStickListAdd(GameObject _obj)
    {
        UIManager.Instance.RhythmNoteEffect();

        if (BroomStick_isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            BroomStick_isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.BROOMSTICK_ADD, _obj);
    }

    public void BroomStickDown()
    {

       myAnim.SetTrigger("BroomStickShow");
        BroomStickListAdd(gameObject);
    }
}
