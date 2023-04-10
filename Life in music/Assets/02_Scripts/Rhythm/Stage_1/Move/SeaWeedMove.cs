using UnityEngine;
using UnityEngine.UI;

public class SeaWeedMove : MonoBehaviour
{
    #region Interface

    public enum SeaWeedPos // 미역의 총 3개 위치
    {
        one,
        two,
        three,
    }


    public static void Add(SeaWeedPos _pos)
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Seaweed)(Clone)");
        }

        var _obj = Resources.Load<SeaWeedMove>("Notes/Stage_01/SeaWeedNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform.GetChild(0), false);
            _inst.seaweedPos = _pos;

            switch (_pos)
            {
                case SeaWeedPos.one:
                    _inst.transform.localPosition = new Vector3(-14.76f, 0f, 0f);
                    break;

                case SeaWeedPos.two:
                    _inst.transform.localPosition = new Vector3(-11f, 0f, 0f);
                    break;

                case SeaWeedPos.three:
                    _inst.transform.localPosition = new Vector3(14.76f, 0f, 0f);
                    break;
            }
        }
    }

    public static void Remove()
    {
        // 자동삭제
    }
    #endregion

    public float moveSpeed = 1f;
    public GameObject animObj = null;


    public static bool isFirst = true;


    private SeaWeedPos seaweedPos;
    private bool isAdd = false;

    private Transform myTrn;
    private SpriteRenderer mySprite;


    private static GameObject mom;
    private bool isStop = false;


    private void Start()
    {
        myTrn = GetComponent<Transform>();
        mySprite = GetComponent<SpriteRenderer>();

        if (animObj.activeSelf)
        {
            animObj.SetActive(false);
        }
    }

    private void Update()
    {
        MoveSeaWeed();
    }

    private void MoveSeaWeed()
    {
        if (isStop) return;

        switch (seaweedPos)
        {

            case SeaWeedPos.one:
                if (myTrn.position.x >= -3.6f)
                {
                    isStop = true;
                    myTrn.position = new Vector3(-3.6f, 0, 0);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                }
                break;

            case SeaWeedPos.two:
                if (myTrn.position.x >= 0)
                {
                    isStop = true;
                    myTrn.position = new Vector2(0f, 0f);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
                }
                break;

            case SeaWeedPos.three:
                if (myTrn.position.x <= 3.6f)
                {
                    isStop = true;
                    myTrn.position = new Vector2(3.6f, 0f);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime;
                }
                break;
        }
    }

    private void AddList(GameObject _obj)
    {
        if (isAdd)
        {
            return;
        }


        isAdd = true;

        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.SEAWEED_ADD, _obj);

    }

    public void SeaweedUp()
    {
        mySprite.enabled = false;
        animObj.SetActive(true);
    }

}
