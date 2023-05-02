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
        }

        else
        {
            Debug.LogError("UmbrellaNote NULL");
        }
    }

    public static void Remove()
    {
        // �ڵ�����
    }
    #endregion

    public float moveSpeed = 1f;
    //public float target;

    private bool isStop = false;

    [Header("NoteAnimation")]
    public Animator noteAnimation = null;

    public static bool isFirst = true;
    private static GameObject mom;
    public Sprite[] sprites = new Sprite[5];

    private void OnEnable()
    {
        //target = targetpos;
    }

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
        Destroy(gameObject);
    }

    private void MoveUmbrella()
    {
        if (isStop) return;

       AddForceObject();
       SettiingRotation();
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

    private Rigidbody2D myrigid;
    private Transform mytrn;

    
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
       myrigid.AddForce(-mytrn.position * 1.75f);
    }

    private void SettiingRotation()
    {
       // float angle = Mathf.Atan2(myrigid.velocity.y, myrigid.velocity.x) * Mathf.Rad2Deg;
        //mytrn.eulerAngles = new Vector3(0, 0, angle);
    }

    public void UmbrellaDown()
    {
       // noteAnimation.SetTrigger("isMove");
    }
}