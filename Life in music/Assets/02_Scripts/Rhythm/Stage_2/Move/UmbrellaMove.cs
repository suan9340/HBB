using UnityEngine;

public class UmbrellaMove : MonoBehaviour
{
    #region Interface

    public enum State
    {
        Move,
    }

    public static float targetpos;
    public static float _pos = 1f;

    public static void Add(State _dir)
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Umbrella)(Clone)");
        }

        //  var _umbrellastandobj = Resources.Load<UmbrellaMove>("Notes/Stage_02/UmbrellaStandNote");
        //    Debug.Log(_umbrellastandobj != null);
        // Instantiate(_umbrellastandobj, mom.transform, false);

        var _obj = Resources.Load<UmbrellaMove>("Notes/Stage_02/UmbrellaNote");
        var _standObj = Resources.Load<UmbrellaStandMove>("Notes/Stage_02/UmbrellaStandNote");

        Debug.Log(_standObj);


        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);

            Instantiate(_standObj, mom.transform , false);

            _inst.dir = _dir;

            switch (_dir)
            {
                case State.Move:
                    _inst.transform.localPosition = new Vector3(11f, _pos, 0f);
                  
                    break;

            }
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
    public float target;

    private State dir;
    private bool isStop = false;

    [Header("NoteAnimation")]
    public Animator noteAnimation = null;


    public static bool isFirst = true;

    private static GameObject mom;


    public Sprite[] sprites = new Sprite[5];


    private void OnEnable()
    {
        target = targetpos;
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
       if(collision.gameObject.name == "UmbrellaStandNote")
        {
           AddList(gameObject);
            gameObject.SetActive(false);
           // Destroy(gameObject);
        }
     
    }

    private void MoveUmbrella()
    {

        if (isStop) return;

        switch (dir)
        {
            case State.Move:
                AddForceObject();
                SettiingRotation();

                break;

        }
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
       // mytrn.eulerAngles = new Vector3(0, 0, angle);
    }

    public void UmbrellaDown()
    {

        noteAnimation.SetTrigger("isMove");
    }
}