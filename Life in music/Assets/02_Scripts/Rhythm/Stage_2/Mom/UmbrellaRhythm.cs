using Unity.VisualScripting;
using UnityEngine;

public class UmbrellaRhythm : TutoMOM, IRhythmMom
{
    public GameObject umbrellaStand;
    private static GameObject mom;
    public UmbrellaStandMove umStandMove;

    private void Awake()
    {
        NoteGen.Instance.IGenUmbrella();
        Invoke("UmbellaStandInst", 1.5f);
    }

    private void UmbellaStandInst()
    {
        var _standObj = Resources.Load<UmbrellaStandMove>("Notes/Stage_02/UmbrellaStandNote");
        mom = GameObject.Find("Rhythm (Umbrella)(Clone)");
        Instantiate(_standObj, mom.transform, false);
        umStandMove = GameObject.Find("UmbrellaStandNote(Clone)").GetComponent<UmbrellaStandMove>();
    }

    protected override void Start()
    {
        base.Start();
        EventManager<GameObject>.StartListening(ConstantManager.UMBRELLA_ADD, AddNoteList);
        CheckingTuto();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Tutoing()
    {
        Tuto();
    }
    protected override void RhythmGaming()
    {
        SetupUmbrella();
        EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
    }

    private void CheckingTuto()
    {
        var _isTutoGO = RhythmManager.Instance.CheckTuto(ConstantManager.SO_STAGE02_UMBRELLA);
        if (_isTutoGO)
        {
            Invoke(nameof(Tutoing), 1.5f);
        }
        else
        {
            isTuto = false;
            StartRhythm();
        }
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.TutoClear();
        TutoManager.Instance.SetActiveFalseText();
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE02_UMBRELLA);
    }

    public void SetupUmbrella()
    {
        var _cnt = noteObjList.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }
        EventManager.TriggerEvent(ConstantManager.CAMERA_SHAKE);
        UIManager.Instance.RhythmNoteEffect();

        var _umonjSelect = _cnt - 1;
        var _obj = noteObjList[_umonjSelect].gameObject;


        _obj.GetComponent<UmbrellaMove>().ReMoveUmbrella();
       umStandMove.ResetUm();
        noteObjList.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        noteObjList.Add(_obj);
    }

    public void Tuto()
    {
        if (TutoManager.Instance.IsTyping) return;

        tutoNum++;
        switch (tutoNum)
        {
            case 1:
                isTuto = true;
                break;

            case 2:
                break;


            case 3:
                break;


            case 4:
                break;

            default:
                isTuto = false;
                StartRhythm();
                break;
        }
    }
}
