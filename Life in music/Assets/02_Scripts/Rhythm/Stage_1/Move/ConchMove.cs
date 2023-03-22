using UnityEngine;

public class ConchMove : MonoBehaviour
{

    private static GameObject conchMom;

    public GameObject conch1 = null;
    public GameObject conch2 = null;
    public GameObject conch3 = null;
    public bool isOne, isTwo, isThree;

    public enum ConchDirection
    {
        one,
        two,
        three,
    }

    public static void ConchAdd(ConchDirection _dir)
    {
        if (conchMom == null)
        {
            conchMom = GameObject.Find("Rhythm (Conch)(Clone)");
        }

        var _conchObj = Resources.Load<ConchMove>("Notes/Stage_01/ConchNote");

        if (_conchObj != null)
        {
            var _inst = Instantiate(_conchObj, conchMom.transform, false);
            _inst.conchDirection = _dir;
            Debug.Log(_dir);
            switch (_dir)
            {
                case ConchDirection.one:
                    break;


                case ConchDirection.two:
                    break;


                case ConchDirection.three:
                    break;

            }
        }
        else
        {
            Debug.LogError("_conchObj NULL");
        }
    }

    public static void Remove()
    {

    }

    public static bool conchMove_isFirst = true;

    public bool isFirst = false;

    private ConchDirection conchDirection;
    private Animator conchAnim = null;
    private RectTransform rect;

    private void Start()
    {
        conchAnim = GetComponent<Animator>();
        conch1 = transform.Find("One").gameObject;
        conch2 = transform.Find("Two").gameObject;
        conch3 = transform.Find("Three").gameObject;
    }

    private void Update()
    {
        MoveConch();
        ConchAnimation();

    }

    private void MoveConch()
    {

        switch (conchDirection)
        {
           case ConchDirection.one:
                if (isOne)
                    break;

                //   conchAnim.SetTrigger("ConchOne");
                 conchAnim.SetTrigger("ConchOneTest");

                isOne = true;
                conch3.SetActive(true);
                Debug.Log($"1");
                AddList(gameObject);


                break;

            case ConchDirection.two:
                if (isTwo)
                    break;

                conchAnim.SetTrigger("ConchTwo");

                isTwo = true;
                conch2.SetActive(true);
                Debug.Log($"2");
                AddList(gameObject);


                break;

            case ConchDirection.three:
                if (isThree)
                    break;

                conchAnim.SetTrigger("ConchThree");

                isThree = true;
                conch1.SetActive(true);
                Debug.Log($"3");
                AddList(gameObject);

                break;

        }
    }

    private void ConchAnimation()
    {
        //애니메이션

    }

    private void AddList(GameObject _obj)
    {

        if (conchMove_isFirst)
        {

            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            conchMove_isFirst = false;
        }

        EventManager<GameObject>.TriggerEvent(ConstantManager.CONCHLIST_ADD, _obj);
    }

    public void ConchDown()
    {
        if (isOne)
        {
            conchAnim.SetTrigger("ConchThreeOut");
            conch3.SetActive(false);



        }
        if (isTwo)
        {
             conchAnim.SetTrigger("ConchTwoOut");
            conch2.SetActive(false);
        }
        if (isThree)
        {
            conchAnim.SetTrigger("ConchOneOut");
            // conchAnim.SetTrigger("ConchThreeOut");
            conch1.SetActive(false);
        }
    }
}
