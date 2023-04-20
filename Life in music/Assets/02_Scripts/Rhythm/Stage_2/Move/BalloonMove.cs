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

            switch (_pos)
            {
                case BalloonPos.Left:

                    break;

                case BalloonPos.Right:

                    break;
            }
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    public BalloonPos balloonPos;
    private static GameObject mom;

    public static bool isFirst = true;

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
