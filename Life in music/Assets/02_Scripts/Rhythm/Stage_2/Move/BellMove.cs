using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellMove : MonoBehaviour
{
    public enum BellPos
    {
        Left,
        Mid,
        Right,
    }

    public static void BellAdd(BellPos _pos)
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Bell)(Clone)");
        }


        var _obj = Resources.Load<BellMove>("Notes/Stage_02/BellNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform.GetChild(0), false);    

            _inst.bellPos = _pos;

            switch (_pos)
            {
                case BellPos.Left:
                    _inst.transform.localPosition = new Vector3(-4f, -6f, 0f);
                    break;

                case BellPos.Mid:
                    _inst.transform.localPosition = new Vector3(0f, -6f, 0f);
                    break;

                case BellPos.Right:
                    _inst.transform.localPosition = new Vector3(4f, -6f, 0f);
                    break;
            }
        }
    }

    public static bool isFirst = true;
    private static GameObject mom;

    private BellPos bellPos;
    public float moveSpeed = 10f;

    private bool isStop = false;

    private Animator myAnim;
    private Transform myTrn;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        myTrn = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveBell();
    }


    private void MoveBell()
    {
        if (isStop) return;

        if (myTrn.position.y >= 0f)
        {
            isStop = true;
            myTrn.position = new Vector3(myTrn.position.x, 0f, myTrn.position.z);
            AddList(gameObject);
        }
        myTrn.position += new Vector3(0, 1, 1) * moveSpeed * Time.deltaTime;
    }

    private void AddList(GameObject _obj)
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            isFirst = false;
        }

        UIManager.Instance.RhythmNoteEffect();
        EventManager<GameObject>.TriggerEvent(ConstantManager.BELL_ADD, _obj);
    }

    public void BellUp()
    {
        myAnim.SetTrigger("upBell");
    }
}
