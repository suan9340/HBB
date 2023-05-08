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
        // 자동삭제
    }
    #endregion

    public float moveSpeed = 1f;
    private bool isStop = false;

    [Header("NoteAnimation")]
    public static Animator noteAnimation = null;

    public static bool isFirst = true;
    private static GameObject mom;

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

    private Rigidbody2D myrigid;
    private Transform mytrn;

    private void FixedUpdate()
    {
        if (isStop)
        {
            return;
        }
        SettiingRotation();
    }

    private void Cashing()
    {
        noteAnimation = GetComponent<Animator>();
        myrigid = GetComponent<Rigidbody2D>();
        mytrn = GetComponent<Transform>();
    }

    private void AddForceObject()
    {
        myrigid.AddForce(-mytrn.position *60f);
    }

    private void ReAddForceObject()
    {
       // myrigid.AddForce(mytrn.position * 60f);
        myrigid.AddForce(new Vector3(mytrn.position.x*3, mytrn.position.y*-1f, mytrn.position.z) * 60f);
    }

    private void SettiingRotation()
    {
        // float angle = Mathf.Atan2(myrigid.velocity.y, myrigid.velocity.x) * Mathf.Rad2Deg;
       // mytrn.eulerAngles = new Vector3(0, 0, angle);
    }
}