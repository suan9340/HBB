using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerRhythm : TutoMOM, IRhythmMom
{
    [Space(20)]
    public GameObject lockerObj = null;

    [Space(20)]
    public List<GameObject> lockerList = new List<GameObject>();
    private List<GameObject> two = new List<GameObject>();


    private int num;
    private readonly WaitForSeconds lockerSec = new WaitForSeconds(0.4f);

    private bool isFirst = true;
    private void Awake()
    {
        NoteGen.Instance.IGenBook();
    }

    protected override void Start()
    {
        base.Start();

        EventManager<GameObject>.StartListening(ConstantManager.LOCKER_ADD, AddNoteList);
        EventManager.StartListening(ConstantManager.LOCKER_RH, LocekerMoveAdd);
        CheckingTuto();
        SetUpList();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void RhythmGaming()
    {
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);

        if (GameManager.Instance.canClick)
        {
            GameManager.Instance.canClick = false;
            SetupLocker();
        }
    }

    protected override void Tutoing()
    {
        Tuto();
    }


    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_LOCKER);
        Invoke(nameof(StartLockerMOM), 1.5f);
    }

    private void SetUpList()
    {
        two.Clear();

        for (int i = 0; i < lockerList.Count; i++)
        {
            two.Add(lockerList[i]);
        }

        SufferList(two);
    }

    private void CheckingTuto()
    {
        var _isTutoGo = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE02_LOCKER);
        if (_isTutoGo)
        {
            Invoke(nameof(Tuto), 1.5f);
        }
        else
        {
            isTuto = false;
            StartRhythm();
        }
    }

    private void StartLockerMOM()
    {
        if (lockerObj == null)
        {
            Debug.Log("LocerObject is NULL!!!");
        }

        lockerObj.gameObject.SetActive(true);
    }



    public void SetupLocker()
    {
        var _cnt = noteObjList.Count;
        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }
        UIManager.Instance.RhythmNoteEffect();
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        var _lockerSelect = _cnt - 1;
        var _obj = noteObjList[_lockerSelect].gameObject;

        _obj.GetComponent<Animator>().SetTrigger("isDoorClose");
        noteObjList.Remove(_obj);
    }

    private void LocekerMoveAdd()
    {
        if (two.Count <= 0)
        {
            SetUpList();
        }



        var _obj = two[0].gameObject;
        _obj.GetComponent<Animator>().SetTrigger("isDoorOpen");
        two.Remove(two[0].gameObject);

        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            isFirst = false;
        }
        UIManager.Instance.RhythmNoteEffect();
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        AddNoteList(_obj);

        //StartCoroutine(RemoveLockerObj(_obj));
    }

    private IEnumerator RemoveLockerObj(GameObject _obj)
    {
        yield return lockerSec;

        if (isFirst)
        {
            RhythmManager.Instance.StartMusic();
            EventManager<float>.TriggerEvent(ConstantManager.RHYTHM_SOUND_START, 0.5f);
            isFirst = false;
        }
        UIManager.Instance.RhythmNoteEffect();
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        AddNoteList(_obj);
        yield break;
    }

    private List<GameObject> SufferList(List<GameObject> _list)
    {
        for (int i = _list.Count - 1; i > 0; i--)
        {
            int _rnd = Random.Range(0, i);

            GameObject tmp = _list[i];
            _list[i] = _list[_rnd];
            _list[_rnd] = tmp;
        }

        return _list;
    }

    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        var _obj1 = tutoObj[1].gameObject.GetComponent<Animator>();
        var _obj2 = tutoObj[2].gameObject.GetComponent<Animator>();

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
                tutoObj[0].SetActive(true);
                TutoManager.Instance.TextingOut(tutoTxt[0]);
                break;

            case 2:
                _obj1.SetTrigger("isDoorOpen");
                _obj2.SetTrigger("isDoorOpen");

                TutoManager.Instance.TextingOut(tutoTxt[1]);
                break;


            case 3:
                TutoManager.Instance.TextingOut(tutoTxt[2]);
                break;


            case 4:
                TutoManager.Instance.TextingOut(tutoTxt[3]);
                break;

            case 5:
                _obj1.SetTrigger("isDoorClose");
                _obj2.SetTrigger("isDoorClose");
                TutoManager.Instance.TextingOut(tutoTxt[4]);
                break;

            default:
                tutoObj[0].SetActive(false);
                isTuto = false;
                StartRhythm();
                break;
        }
    }
}
