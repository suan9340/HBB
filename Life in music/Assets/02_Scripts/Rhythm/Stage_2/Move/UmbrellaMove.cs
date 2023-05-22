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
            _inst.transform.localPosition = new Vector3(11f, _pos, 0f);
            Debug.Log("qwe");
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

    private void OnEnable()
    {
        //target = targetpos;
    }

    //private void Awake()
    //{
    //    transform.localPosition = new Vector3(11f, 1f, 0f);
    //}

    private void Start()
    {
        Cashing();
        AddForceObject();
    }

    private void Update()
    {
        MoveUmbrella();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AddList(gameObject);
        gameObject.SetActive(false);
    }

    public void ReMoveUmbrella()
    {
        gameObject.transform.localPosition = new Vector3(-2.5f, 0f, 0f);
        gameObject.SetActive(true);
        ReAddForceObject();
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
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
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

    private void AddForceObject()
    {
        myrigid.AddForce(-mytrn.position * 60f);
    }

    private void ReAddForceObject()
    {
        myrigid.AddForce(new Vector3(mytrn.position.x * 3, mytrn.position.y * -1f, mytrn.position.z) * 60f);
    }
}