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
                    _inst.transform.localPosition = new Vector3(-1476f, 0f, 0f);
                    break;

                case SeaWeedPos.two:
                    _inst.transform.localPosition = new Vector3(-1100f, 0f, 0f);
                    break;

                case SeaWeedPos.three:
                    _inst.transform.localPosition = new Vector3(1476f, 0f, 0f);
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

    private RectTransform rect;
    private Image image;


    private static GameObject mom;
    private bool isStop = false;


    private void Start()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();

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
                if (rect.anchoredPosition.x >= -366f)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(-366f, 0);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
                }
                break;

            case SeaWeedPos.two:
                if (rect.anchoredPosition.x >= 0)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(0f, 0f);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
                }
                break;

            case SeaWeedPos.three:
                if (rect.anchoredPosition.x <= 366f)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(366f, 0f);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(-10, 0) * moveSpeed * Time.deltaTime;
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
        UIManager.Instance.RhythmNoteEffect();

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
        image.enabled = false;
        animObj.SetActive(true);
    }

}
