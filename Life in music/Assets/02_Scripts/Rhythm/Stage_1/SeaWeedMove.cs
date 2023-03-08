using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SeaWeedMove : MonoBehaviour
{
    #region Interface

    public enum SeaWeedPos // �̿��� �� 3�� ��ġ
    {
        one,
        two,
        three,
    }

    public static float targetpos;
    public static float _pos = -220f;

    public static void Add(SeaWeedPos _pos) 
    {
       
        if (canvas == null)  // ���� ĵ������ ������?
        {
            canvas = GameObject.FindWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
            // canvas�� ���ӿ�����Ʈ���� TAG_RHYTHMCANVAS�� �±׸� ���� ������Ʈ�� �־��ش�,
        }

        var _obj = Resources.Load<ShellfishMove>("Notes/Stage_01/SeaWeedNote");
        // _obj�� ���ҽ� ���Ͽ� �ִ� ���� �������� �־��ش�.

        if (_obj != null) // ���� ������Ʈ�� ��ĭ�� �ƴ϶��?
        {
            var _inst = Instantiate(_obj, canvas.transform, false);
            // _inst �� �����ϰ�, ����ٰ� ������ ������ �������� ĵ���� �ڽ����� �ν��Ͻ� ���ش�.
            // �׸��� ĵ���� ũ��� ũ�⸦ ����.

            switch (_pos) // �Լ��� ȣ���� �� �̿��� ���� ��ġ�� _pos�� ����ġ�� ����.
            {
                case SeaWeedPos.one:

                    Debug.Log("111");

                   // _inst.transform.localPosition = new Vector3(1100f, 200f, 0f);
                    // _inst �ν��Ͻ��� ����� ������Ʈ�� ��ġ�� ������ ���� �ٲ۴�.
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
        // �ڵ�����
    }
    #endregion

    public float moveSpeed = 1f;
    // ����� �̵� �ӵ�
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
        // ���� isStop ���¸�, return.

        switch (seaweedPos)
        {
            case SeaWeedPos.one: // ���� ù��° �̿��̶��?
                AddList(gameObject);
                break;

            case SeaWeedPos.two: // ���� �ι�° �̿��̶��?
                AddList(gameObject);
                break;

            case SeaWeedPos.three: // ���� ����° �̿��̶��?
                AddList(gameObject);
                break;
        }


        }

    private void AddList(GameObject _obj) 
    {
        UIManager.Instance.RhythmNoteEffect(); // ����Ʈ

        if (isFirst) //���� ó���̶��
        {
            RhythmManager.Instance.StartMusic(); // StartMusic �־��ְ�
            isFirst = false; // isFirst ���ش�.
        }
       
    }

    //public void ShellfishDown()
    //{
    //    noteAnimation.SetTrigger("isDown");
    //}
}
