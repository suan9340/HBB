using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class UmbrellaMove : MonoBehaviour
{
    #region Interface
    public enum Direction
    {
        left,
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
            mom = GameObject.Find("Rhythm (Umbrella)(Clone)");
        }

        var _obj = Resources.Load<UmbrellaMove>("Notes/Stage_02/UmbrellaNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);
            _inst.dir = _dir;

            switch (_dir)
            {
                case Direction.left:
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
        MoveUmbrella();
    }

    private void MoveUmbrella()
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

    public void UmbrellaDown()
    {
        noteAnimation.SetTrigger("isDown");
    }
}
