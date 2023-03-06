using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Drawing;

public class RockMove : MonoBehaviour
{

    private static Canvas canvas;
    private static int dirnum = 0;

    private static Vector3 leftVec = new Vector3(-1314f, 658f, 0f);
    private static Vector3 rightVec = new Vector3(1314f, 658f, 0f);
    public static void Add(bool _isTrue)
    {

        // isTrue∏È µπ∏Ê¿Ã
        var _rockobj = Resources.Load<RockMove>("Notes/Stage_01/RockNote");
        var _fishkobj = Resources.Load<RockMove>("Notes/Stage_01/FishNote");

        if (canvas == null)
        {
            canvas = GameObject.FindWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
        }



        if (_rockobj != null && _fishkobj != null)
        {
            if (_isTrue)
            {
                var _instRock = Instantiate(_rockobj, canvas.transform, false);

                if (dirnum < 2)
                {
                    _instRock.transform.localPosition = rightVec;
                }
                else
                {
                    _instRock.transform.localPosition = leftVec;
                }
            }
            else
            {
                var _insFish = Instantiate(_fishkobj, canvas.transform, false);

                if (dirnum < 2)
                {
                    _insFish.transform.localPosition = rightVec;
                }
                else
                {
                    _insFish.transform.localPosition = leftVec;
                }
            }
        }
        else
        {
            Debug.LogError("rockNote OR fishNote NULL");
        }


        dirnum++;

        if (dirnum == 4)
        {
            dirnum = 0;
        }

    }


    public static void Remove()
    {

    }


    public enum Type
    {
        rock,
        fish,
    }

    public Type type;


    private Rigidbody2D myrigid;
    private Animator myanim;
    private Transform mytrn;

    public float bulletSpeed;
    public static bool isFirst = true;

    private void Start()
    {
        Cashing();
        AddForceObject();
        AddList(gameObject);


        Invoke(nameof(DestroyRock), 2f);
    }

    private void FixedUpdate()
    {
        SettiingRotation();
    }

    private void Cashing()
    {
        myrigid = GetComponent<Rigidbody2D>();
        mytrn = GetComponent<Transform>();
        myanim = GetComponent<Animator>();
    }

    private void AddForceObject()
    {
        myrigid.AddForce(-mytrn.position * bulletSpeed);
    }

    private void SettiingRotation()
    {
        float angle = Mathf.Atan2(myrigid.velocity.y, myrigid.velocity.x) * Mathf.Rad2Deg;
        mytrn.eulerAngles = new Vector3(0, 0, angle);
    }

    public void CheckType()
    {
        if (type == Type.rock)
        {
            Debug.Log("This is rock");
            myanim.SetTrigger("isClickRock");
        }
        else if (type == Type.fish)
        {
            Debug.Log("This is Fish");
        }
    }

    private void AddList(GameObject _obj)
    {
        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            isFirst = false;
        }
        EventManager<GameObject>.TriggerEvent(ConstantManager.ROCK_ADD, _obj);
    }

    private void DestroyRock()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
