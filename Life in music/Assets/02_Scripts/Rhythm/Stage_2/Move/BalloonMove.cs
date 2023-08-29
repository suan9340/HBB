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
    public static void BalloonAdd()
    {

        if (mom == null)
        {
            mom = GameObject.Find("Rhythm (Balloon)(Clone)");
        }

        var _obj = Resources.Load<BalloonMove>("Notes/Stage_02/BalloonNote");
        if (_obj != null)
        {
            var _inst = Instantiate(_obj, mom.transform.GetChild(0), false);
            var _posX = 0f;

            switch (num)
            {
                case 0:
                    _posX = -1;
                    _inst.endPos = -1.1f;
                    break;

                case 1:
                    _posX = 0;
                    _inst.endPos = -2.6f;

                    break;

                case 2:
                    _posX = 0;
                    _inst.endPos = -0.02f;
                    break;

                case 3:
                    _posX = 1;
                    _inst.endPos = -1.08f;
                    break;
            }

            //_inst.transform.position = new Vector2(_posX + 8, _inst.transform.position.y);
            _inst.transform.position = new Vector2(_posX, _inst.endPos + 8f);
        }

        if (num >= 3)
        {
            num = 0;
        }
        else
        {
            num++;
        }

    }


    public BalloonPos balloonPos;
    public float endPos;
    public float moveSpeed = 4f;

    private static GameObject mom;

    public static bool isFirst = true;
    private static int num;

    private Transform myTrn = null;
    private Animator myAnim = null;

    private bool isStop = false;
    private BalloonRhythm ballMOM;

    private void Start()
    {
        ballMOM = GetComponent<BalloonRhythm>();
        myTrn = GetComponent<Transform>();
        myAnim = GetComponentInChildren<Animator>();
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
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            isFirst = false;
        }

        UIManager.Instance.RhythmNoteEffect();
        EventManager<GameObject>.TriggerEvent(ConstantManager.BALLOON_ADD, _obj);
    }

    public void BalloonUp()
    {
        myAnim.SetTrigger("isPop");
    }
}
