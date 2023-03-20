using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using static ConchMove;
using static UnityEngine.GraphicsBuffer;

public class ConchMove : MonoBehaviour
{
   
    //public Image musicNote;
    private static GameObject conchMom;

    public GameObject conch1 = null;
    public GameObject conch2 = null;
    public GameObject conch3 = null;
    public GameObject conch4 = null;

    public bool isOne, isTwo, isThree, isFour;

    public enum ConchDirection
    {
        one,
        two,
        three,
        four,
    }

    public static void ConchAdd(ConchDirection _dir)
    {
        if (conchMom == null)
        {
           conchMom = GameObject.Find("Rhythm (Conch)(Clone)");
        }

        var _conchObj = Resources.Load<ConchMove>("Notes/Stage_01/ConchNote");

        if (_conchObj != null)
        {
          var _inst = Instantiate(_conchObj, conchMom.transform, false);
            _inst.conchDirection = _dir;
           // Debug.Log(_dir);
            //switch (_dir)
            //{
            //    case ConchDirection.one:
            //        break;


            //    case ConchDirection.two:
            //        break;


            //    case ConchDirection.three:
            //        break;


            //    case ConchDirection.four:
            //        break;
            //}
        }
        else
        {
          Debug.LogError("_conchObj NULL");
        }
    }

    public static void Remove()
    {

    }

    public static bool conchMove_isFirst = true;

    public bool isFirst = false;

    private ConchDirection conchDirection;
    private Animator conchAnim = null;
    private RectTransform rect;

    private void Start()
    {
        conchAnim = GetComponent<Animator>();
        conch1 = transform.Find("One").gameObject;
        conch2 = transform.Find("Two").gameObject;
        conch3 = transform.Find("Three").gameObject;
        conch4 = transform.Find("Four").gameObject;

    }

    private void Update()
    {
        MoveConch();
        ConchAnimation();
    }

    private void MoveConch()
    {
         switch (conchDirection)
        {
            case ConchDirection.one:
                if (isOne)
                    break;

                isOne = true;
                conch1.SetActive(true);
                 Debug.Log($"1");
                
                AddList(gameObject);

                conchAnim.SetTrigger("ConchOne");
                break;

            case ConchDirection.two:
                if (isTwo)
                    break;

                isTwo = true;
                conch2.SetActive(true);
                Debug.Log($"2");
                AddList(gameObject);

                conchAnim.SetTrigger("ConchTwo");
                break;

            case ConchDirection.three:
                if (isThree)
                    break;

                isThree = true;
                conch3.SetActive(true);
                Debug.Log($"3");
                AddList(gameObject);

                conchAnim.SetTrigger("ConchThree");
                break;

            case ConchDirection.four:

                Debug.Log("초기화");
                //if (isFour)
                //    break;

                //isFour = true;
                //conch4.SetActive(true);
                //Debug.Log($"4");
                //AddList(gameObject);

                //conchAnim.SetTrigger("ConchFour");
                break;
        }
    }

    private void ConchAnimation()
    {
        //애니메이션
       
    }

    private void AddList(GameObject _obj)
        {

        if (conchMove_isFirst)
        {

            RhythmManager.Instance.StartMusic();
            EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
            conchMove_isFirst = false;
        }
       
         EventManager<GameObject>.TriggerEvent(ConstantManager.CONCHLIST_ADD, _obj);
    }

    public void ConchDown()
    {
        if (isOne)
        {
            conchAnim.SetTrigger("ConchOneOut");
           // conch1.SetActive(false);
        }
        if (isTwo)
        {
            conchAnim.SetTrigger("ConchTwoOut");
          //  conch2.SetActive(false);
        }
        if (isThree)
        {
            conchAnim.SetTrigger("ConchThreeOut");
            // conch3.SetActive(false);
        }
        if (isFour)
        {
            conchAnim.SetTrigger("ConchFourOut");
            //    conch4.SetActive(false);
        }
    }
}
