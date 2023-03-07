using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class ShellfishMove : MonoBehaviour
{
    #region Interface
    public enum Direction
    {
        left,
        right,
        up,
        down,
    }

    public static float targetpos;
    public static float _pos = -220f;

    public static void Add(Direction _dir)
    {
        if (_pos == -40)
        {
            _pos = -220f;
        }

        _pos += 20;
        targetpos = _pos;

        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Shellfish)(Clone)");
        }

        var _obj = Resources.Load<ShellfishMove>("Notes/Stage_01/ShellfishNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);
            _inst.dir = _dir;

            switch (_dir)
            {
                case Direction.left:
                    _inst.transform.localPosition = new Vector3(1100f, _pos, 0f);
                    break;


                case Direction.right:
                    _inst.transform.localPosition = new Vector3(-1100f, _pos, 0f);

                    break;


                case Direction.up:
                    _inst.transform.localPosition = new Vector3(0f, -1100f, 0f);
                    break;


                case Direction.down:

                    _inst.transform.localPosition = new Vector3(0f, 1100f, 0f);
                    break;

            }
        }
        else
        {
            Debug.LogError("ShellfishNote NULL");
        }


    }

    public static void Remove()
    {
        // 자동삭제
    }
    #endregion


    public float moveSpeed = 1f;
    public float target;

    private Direction dir;
    private bool isStop = false;

    [Header("NoteAnimation")]
    public Animator noteAnimation = null;


    public static bool isFirst = true;

    private RectTransform rect;
    private static GameObject mom;

    private void OnEnable()
    {
        target = targetpos;
    }

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        noteAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveShell();
    }

    private void MoveShell()
    {
        if (isStop) return;

        switch (dir)
        {
            case Direction.left:

                if (rect.anchoredPosition.x <= 0)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(-10, 0) * moveSpeed * Time.deltaTime;
                }

                break;



            case Direction.right:
                if (rect.anchoredPosition.x >= 0)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
                }
                break;



            case Direction.down:
                if (rect.anchoredPosition.y <= target)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(0, -10) * moveSpeed * Time.deltaTime;
                }
                break;



            case Direction.up:
                if (rect.anchoredPosition.y >= target)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(0, 10) * moveSpeed * Time.deltaTime;
                }
                break;
        }
    }

    // todo 관리자가 들고있어야하는거 ShellfishRhythm
    private void AddList(GameObject _obj)
    {
        UIManager.Instance.RhythmNoteEffect();

        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.SHELLFISHLIST_ADD, _obj);
    }

    public void ShellfishDown()
    {
        noteAnimation.SetTrigger("isDown");
    }
}
