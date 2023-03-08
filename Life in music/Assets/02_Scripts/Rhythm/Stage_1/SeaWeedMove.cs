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
    public static float _pos = -220f;

    public static void Add(SeaWeedPos _pos) 
    {
       
        if (canvas == null)  // 만약 캔버스가 없으면?
        {
            canvas = GameObject.FindWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
            // canvas에 게임오브젝트에서 TAG_RHYTHMCANVAS의 태그를 가진 오브젝트를 넣어준다,
        }

        var _obj = Resources.Load<ShellfishMove>("Notes/Stage_01/SeaWeedNote");
        // _obj에 리소스 파일에 있는 것을 프리팹을 넣어준다.

        if (_obj != null) // 위에 오브젝트가 빈칸이 아니라면?
        {
            var _inst = Instantiate(_obj, canvas.transform, false);
            // _inst 를 정의하고, 여기다가 위에서 정의한 프리팹을 캔버스 자식으로 인스턴스 해준다.
            // 그리고 캔버스 크기와 크기를 맞춤.

            switch (_pos) // 함수를 호출할 때 미역의 종류 위치인 _pos로 스위치문 시작.
            {
                case SeaWeedPos.one:

                    Debug.Log("111");

                   // _inst.transform.localPosition = new Vector3(1100f, 200f, 0f);
                    // _inst 인스턴스한 물고기 오브젝트의 위치를 다음과 같이 바꾼다.
                    break;

                case SeaWeedPos.two:
                    Debug.Log("222");
                    break;

                case SeaWeedPos.three:
                    Debug.Log("333");
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
    // 물고기 이동 속도
    public float target;

    private SeaWeedPos seaweedPos; // 
    // private Direction dir;
    private bool isStop = false; // 

    [Header("NoteAnimation")]
    public Animator noteAnimation = null;


    public static bool isFirst = true;

    private RectTransform rect;
    private Transform trn;
    private static Canvas canvas;


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
        MoveSeaWeed();
    }

    private void MoveSeaWeed()
    {
        if (isStop) return;
        // 만약 isStop 상태면, return.

        switch (seaweedPos)
        {
            case SeaWeedPos.one: // 만약 첫번째 미역이라면?
                AddList(gameObject);
                break;

            case SeaWeedPos.two: // 만약 두번째 미역이라면?
                AddList(gameObject);
                break;

            case SeaWeedPos.three: // 만약 세번째 미역이라면?
                AddList(gameObject);
                break;
        }


        }

    private void AddList(GameObject _obj) 
    {
        UIManager.Instance.RhythmNoteEffect(); // 이펙트

        if (isFirst) //만약 처음이라면
        {
            RhythmManager.Instance.StartMusic(); // StartMusic 넣어주고
            isFirst = false; // isFirst 꺼준다.
        }
       
    }

    //public void ShellfishDown()
    //{
    //    noteAnimation.SetTrigger("isDown");
    //}
}
