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

        if (canvas == null) 
        {
            canvas = GameObject.FindWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
        }

        var _obj = Resources.Load<SeaWeedMove>("Notes/Stage_01/SeaWeedNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, canvas.transform, false);
           
            switch (_pos)
            {
                case SeaWeedPos.one:
                    _inst.transform.localPosition = new Vector3(5, _swPos, 0f);
                    break;

                case SeaWeedPos.two:
                    _inst.transform.localPosition = new Vector3(500, _swPos, 0f);
                    break;

                case SeaWeedPos.three:
                    _inst.transform.localPosition = new Vector3(0, _swPos, 0f);
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

    private SeaWeedPos seaweedPos;
   
    public static bool isFirst = true;

    private RectTransform rect;
    
    private static Canvas canvas;


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
                AddList(gameObject);
                break;

            case SeaWeedPos.two:
                AddList(gameObject);
                break;

            case SeaWeedPos.three: 
                AddList(gameObject);
                break;
        }
}

    private void AddList(GameObject _obj) 
    {
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
