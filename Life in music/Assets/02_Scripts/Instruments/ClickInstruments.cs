using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickInstruments : ImageSizeInterface
     , IPointerClickHandler
    , IPointerExitHandler
{
    [Space(20)]
    public GameObject instrumetnsObj = null;

    [Space(20)]
    public DefineManager.Stage_01_Inst instruments;
    public int num;
    public Canvas rhythmCanvas;
    public ScriptableObject a;

    protected override void Start()
    {
        base.Start();

        if (rhythmCanvas == null)
        {
            rhythmCanvas = GameObject.FindGameObjectWithTag(ConstantManager.TAG_RHYTHMCANVAS).GetComponent<Canvas>();
        }

        if (effectAudio == null && clip != null)
        {
            CheckAudioComponents();
        }

    }

    private void CheckStage()
    {
        GameObject _instante = null;
        GameObject _loadObj = null;


        var _stage = GameManager.Instance.GetCurrentStage();

        switch (_stage)
        {
            case DefineManager.StageNames.Sea_01:
                Stage01_SO _so1 = Resources.Load<Stage01_SO>("SO/Stage/Stage1RhythmSO");
                _loadObj = _so1.infos[num].stageRhythm;
                InstantiateRhythm(_instante, _loadObj);
                break;



            case DefineManager.StageNames.School_02:
                Stage02_SO _so2 = Resources.Load<Stage02_SO>("SO/Stage/Stage2RhythmSO");
                _loadObj = _so2.infos[num].stageRhythm;
                InstantiateRhythm(_instante, _loadObj);
                break;



            case DefineManager.StageNames.PlayGround_03:


                break;



            case DefineManager.StageNames.Cafe_04:

                break;
        }

       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.GetGameState() == DefineManager.GameState.Rhythm) return;

        GameManager.Instance.SettingGameState(DefineManager.GameState.Rhythm);


        ImageSizeBig();
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        instrumetnsObj.SetActive(true);

        CheckStage();
        //CheckInstrumentsAndReadyRyhthm();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageSizeSmall();
    }

    private void CheckInstrumentsAndReadyRyhthm()
    {
        GameObject _loadObj = null;
        GameObject _instante = null;

        switch (instruments)
        {
            case DefineManager.Stage_01_Inst.Shellfish:

                _loadObj = Resources.Load<GameObject>("Rhythm/Stage_01/Rhythm (Shellfish)");
                InstantiateRhythm(_instante, _loadObj);

                break;


            case DefineManager.Stage_01_Inst.Starfish:

                _loadObj = Resources.Load<GameObject>("Rhythm/Stage_01/Rhythm (Starfish)");
                InstantiateRhythm(_instante, _loadObj);

                break;


            case DefineManager.Stage_01_Inst.Seaweed:

                _loadObj = Resources.Load<GameObject>("Rhythm/Stage_01/Rhythm (Seaweed)");
                InstantiateRhythm(_instante, _loadObj);

                break;


            case DefineManager.Stage_01_Inst.Rock:

                _loadObj = Resources.Load<GameObject>("Rhythm/Stage_01/Rhythm (Rock)");
                InstantiateRhythm(_instante, _loadObj);

                break;


            case DefineManager.Stage_01_Inst.Conch:

                _loadObj = Resources.Load<GameObject>("Rhythm/Stage_01/Rhythm (Conch)");
                InstantiateRhythm(_instante, _loadObj);

                break;
        }
    }

    private void InstantiateRhythm(GameObject _instobj, GameObject _loadobj)
    {
        _instobj = Instantiate(_loadobj);
        _instobj.transform.SetParent(rhythmCanvas.transform, false);
        RhythmManager.Instance.SettingCurRhythm(_instobj);
    }
}
