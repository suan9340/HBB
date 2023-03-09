using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeaWeedMove : MonoBehaviour
{
    #region Interface

    public enum SeaWeedPos // 미역의 총 3개 위치
    {
        one,
        two,
        three,
    }

    public static float targetpos;

    public static float _swPos = -220f;

    public static void Add(SeaWeedPos _pos)
    {
        _swPos += 20;

        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Seaweed)(Clone)");
        }

        var _obj = Resources.Load<SeaWeedMove>("Notes/Stage_01/SeaWeedNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform, false);
            _inst.seaweedPos = _pos;

            switch (_pos)
            {
                case SeaWeedPos.one:
                    _inst.transform.localPosition = new Vector3(1100f, _swPos, 0f);
                    break;

                case SeaWeedPos.two:
                    _inst.transform.localPosition = new Vector3(-1100f, _swPos, 0f);
                    break;

                case SeaWeedPos.three:
                    _inst.transform.localPosition = new Vector3(1100f, _swPos, 0f);
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
    public float target;


    public static bool isFirst = true;


    private SeaWeedPos seaweedPos;
    private bool isAdd = false;


    private RectTransform rect;
    private static GameObject mom;

    private bool isStop = false;


    private void OnEnable()
    {
        target = targetpos;
    }


    private void Start()
    {
        rect = GetComponent<RectTransform>();

    }

    private void Update()
    {
        MoveSeaWeed();
    }

    private void MoveSeaWeed()
    {

        switch (seaweedPos)
        {

            case SeaWeedPos.one:
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

            case SeaWeedPos.two:
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

            case SeaWeedPos.three:
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
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.SEAWEED_ADD, _obj);

    }

}
