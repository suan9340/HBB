using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public static void Add(Direction _dir)
    {
        var _obj = Resources.Load<ShellfishMove>("Notes/Stage_01/ShellfishNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj);
            _inst.dir = _dir;
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

    public float targetpos;
    public float moveSpeed = 1f;

    [Space(10)]
    [Header("Check")]
    private Direction dir;
    private bool isStop = false;

    [Header("NoteAnimation")]
    public Animator noteAnimation = null;
    public bool isFirst = false;

    private RectTransform rect;
    private Transform trn;
    private Canvas canvas;

    private void OnEnable()
    {
        //canvas = GameObject.FindWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
        //trn = GetComponent<Transform>();

        //if (!isFirst)
        //    trn.SetParent(canvas.transform, false);
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

                if (rect.anchoredPosition.x <= targetpos)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(targetpos, rect.anchoredPosition.y);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(-10, 0) * moveSpeed * Time.deltaTime;
                }

                break;



            case Direction.right:
                if (rect.anchoredPosition.x >= targetpos)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(targetpos, rect.anchoredPosition.y);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(10, 0) * moveSpeed * Time.deltaTime;
                }
                break;



            case Direction.down:
                if (rect.anchoredPosition.y <= targetpos)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, targetpos);
                    AddList(gameObject);
                }
                else
                {
                    rect.anchoredPosition += new Vector2(0, -10) * moveSpeed * Time.deltaTime;
                }
                break;



            case Direction.up:
                if (rect.anchoredPosition.y >= targetpos)
                {
                    isStop = true;
                    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, targetpos);
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
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.SHELLFISHLIST_ADD, _obj);
        UIManager.Instance.RhythmNoteEffect();
    }

    public void ShellfishDown()
    {
        noteAnimation.SetTrigger("isDown");
    }
}
