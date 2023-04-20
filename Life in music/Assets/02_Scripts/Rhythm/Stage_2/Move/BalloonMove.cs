using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    public enum BalloonPos
    {
        Left,
        Right,
    }
    public static void BalloonAdd(BalloonPos _pos)
    {
        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Balloon)(Clone)");
        }

        var _obj = Resources.Load<BalloonMove>("Notes/Stage_02/BalloonNote");

        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform.GetChild(0), false);

            _inst.balloonPos = _pos;

            var _randX = Random.Range(-7f, 7f);
            var _randY = Random.Range(-3f, 1.3f);

            _inst.transform.position = new Vector3(_randX, 8f, 0f);

            _inst.endPos = _randY;

            //switch (_pos)
            //{
            //    case BalloonPos.Left:
            //        _inst.endPos = -2f;
            //        break;

            //    case BalloonPos.Right:
            //        _inst.endPos = 1f;
            //        break;
            //}

        }
    }



    public BalloonPos balloonPos;
    public float endPos;
    public float moveSpeed = 4f;

    private static GameObject mom;

    public static bool isFirst = true;

    private Transform myTrn = null;
    private Animator myAnim = null;

    private bool isStop = false;
    private void Start()
    {
        myTrn = GetComponent<Transform>();
        myAnim = GetComponentInChildren<Animator>();
        endPos = -1f;
    }

    private void Update()
    {
        MoveBalloon();
    }

    private void MoveBalloon()
    {
        if (isStop) return;

        if (myTrn.position.y <= endPos)
        {
            myAnim.SetTrigger("isEndB");
            isStop = true;
            myTrn.position = new Vector2(myTrn.position.x, endPos);
            Addlist(gameObject);
        }

        myTrn.position += new Vector3(0, -1, 0) * moveSpeed * Time.deltaTime;
    }

    private void Addlist(GameObject _obj)
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            isFirst = false;
        }

        EventManager<GameObject>.TriggerEvent(ConstantManager.BALLOON_ADD, _obj);
    }

    public void BalloonUp()
    {
        Debug.Log("Ballonremove");
    }
}
