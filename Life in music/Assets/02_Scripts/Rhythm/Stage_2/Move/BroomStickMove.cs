
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BroomStickMove : MonoBehaviour
{
    private static GameObject mom;
    public static bool isFirst = true;
    private bool isStop = false;

    private Transform myTrn;

    
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
            _inst.transform.localPosition = new Vector3(-10f, -1f, 0f);
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
        myTrn = GetComponent<Transform>();

        if (isFirst)
        {
            Debug.Log("음악 시작");
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            isFirst = false;
        }
    }

    private void Update()
    {
        if (isStop) return;

        if (myTrn.position.x >= 0f)
        {
            isStop = true;
            myTrn.position = new Vector2(0, -1);
            AddList(gameObject);
        }
        else
        {
            myTrn.position += new Vector3(5, 0) * 3f * Time.deltaTime;
        }
    }

    void AddList(GameObject _obj)
    {
        EventManager<GameObject>.TriggerEvent(ConstantManager.BROOMSTICK_ADD, _obj);
        myAnim.SetTrigger("BroomStickShow");
    }

    public void BroomStickDown()
    {
        myAnim.SetTrigger("BroomStickClick");
        BroomStickDestroy();
    }

    public void BroomStickDestroy()
    {
        Destroy(gameObject);
    }
}
