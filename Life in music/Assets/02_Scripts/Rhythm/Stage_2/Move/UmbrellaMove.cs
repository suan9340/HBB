using DG.Tweening;
using UnityEngine;

public class UmbrellaMove : MonoBehaviour
{
    #region Interface

    public static float targetpos;
    public static float _pos = 1f;

    public static void Add()
    {

        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Umbrella)(Clone)");
        }

        var _obj = Resources.Load<UmbrellaMove>("Notes/Stage_02/UmbrellaNote");
        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);
            _inst.transform.localPosition = new Vector3(0f, _pos, 0f);
        }
        else
        {
            Debug.LogError("UmbrellaNote NULL");
        }
    }

    public static void Remove()
    {
        // 자동삭제
    }
    #endregion

    public float moveSpeed = 1f;
    private bool isStop = false;

    private Animator noteAnimation = null;
    private Rigidbody2D myrigid;
    private Transform mytrn;

    public static bool isFirst = true;
    private static GameObject mom;


    private void Start()
    {
        Cashing();
        Vector3 firstPos = Vector3.zero;
        Vector3 secondPos = firstPos + new Vector3(3, 1f, 0);
        Vector3 thirdPos = firstPos + new Vector3(6, -1f, 0);

        transform.DOPath(new[] { secondPos, firstPos + Vector3.up, secondPos + Vector3.left * 2,
            thirdPos, secondPos + Vector3.right * 2, thirdPos + Vector3.up }, 1f, PathType.CubicBezier).SetEase(Ease.Unset);
    }

    private void Update()
    {
        if(gameObject.transform.position.x > 5)
        {
            AddList(gameObject);
        }
        
    }
    private void MoveUmbrella()
    {
        if (isStop) return;
    }

    private void AddList(GameObject _obj)
    {
        UIManager.Instance.RhythmNoteEffect();
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.UMBRELLA_ADD, _obj);
    }

    private void FixedUpdate()
    {
        if (isStop)
        {
            return;
        }
    }

    private void Cashing()
    {
        noteAnimation = GetComponent<Animator>();
        myrigid = GetComponent<Rigidbody2D>();
        mytrn = GetComponent<Transform>();
    }
}