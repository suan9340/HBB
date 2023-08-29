using UnityEngine;
using static ConchMove;

public class ConchMove : MonoBehaviour
{
    private static GameObject conchMom;

    public enum ConchDirection
    {
        one,
        two,
        three,
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
        }
        else
        {
            Debug.LogError("conchObj NULL");
        }
    }

    public static void Remove()
    {

    }

    public static bool isFirst = true;

    public ConchDirection conchDirection;
    private Animator conchAnim = null;

    private void Start()
    {
        conchAnim = GetComponent<Animator>();
        MoveConch();
    }


    private void MoveConch()
    {
        switch (conchDirection)
        {

            case ConchDirection.one:

                conchAnim.SetTrigger("ConchOne");
                Invoke(nameof(ConchOne_AddList), 0.6f);

                break;



            case ConchDirection.two:

                conchAnim.SetTrigger("ConchTwo");
                Invoke(nameof(ConchOne_AddList), 0.6f);

                break;



            case ConchDirection.three:

                conchAnim.SetTrigger("ConchThree");
                Invoke(nameof(ConchOne_AddList), 0.6f);

                break;
        }
    }

    void ConchOne_AddList()
    {
        AddList(gameObject);
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

        EventManager<GameObject>.TriggerEvent(ConstantManager.CONCHLIST_ADD, _obj);
    }


    public void ConchDown()
    {
        switch (conchDirection)
        {
            case ConchDirection.one:
                conchAnim.SetTrigger("ConchThreeOut");
                break;


            case ConchDirection.two:
                conchAnim.SetTrigger("ConchTwoOut");
                break;


            case ConchDirection.three:
                conchAnim.SetTrigger("ConchOneOut");
                break;
        }
    }
}
