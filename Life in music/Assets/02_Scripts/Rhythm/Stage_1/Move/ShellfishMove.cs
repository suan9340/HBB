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
    public static float _pos = -1.2f;

    public static void Add(Direction _dir)
    {

        if (_pos >= 0.4f)
        {
            _pos = -1.2f;
        }

        _pos += 0.2f;
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
                    _inst.transform.localPosition = new Vector3(11f, _pos, 0f);
                    break;


                case Direction.right:
                    _inst.transform.localPosition = new Vector3(-11f, _pos, 0f);

                    break;


                case Direction.up:
                    _inst.transform.localPosition = new Vector3(0f, -11f, 0f);
                    break;


                case Direction.down:

                    _inst.transform.localPosition = new Vector3(0f, 11f, 0f);
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

    private Transform myTrn;
    private static GameObject mom;

    private void OnEnable()
    {
        target = targetpos;
    }

    private void Start()
    {
        myTrn = GetComponent<Transform>();
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

                if (myTrn.position.x <= 0)
                {
                    isStop = true;
                    myTrn.position = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(-10, 0) * moveSpeed * Time.deltaTime;
                }

                break;

            case Direction.right:

                if (myTrn.position.x >= 0)
                {
                    isStop = true;
                    myTrn.position = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(10, 0) * moveSpeed * Time.deltaTime;
                }

                break;



            case Direction.down:
                if (myTrn.position.y <= target)
                {
                    isStop = true;
                    myTrn.position = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(0, -10) * moveSpeed * Time.deltaTime;
                }
                break;



            case Direction.up:
                if (myTrn.position.y >= target)
                {
                    isStop = true;
                    myTrn.position = new Vector2(0, target);
                    AddList(gameObject);
                }
                else
                {
                    myTrn.position += new Vector3(0, 10) * moveSpeed * Time.deltaTime;
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
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.SHELLFISHLIST_ADD, _obj);
    }

    public void ShellfishDown()
    {
        noteAnimation.SetTrigger("isDown");
    }
}
