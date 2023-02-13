using System.Collections;
using System.Collections.Generic;
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
    public Canvas rhythmCanvas;

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
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.GetGameState() == DefineManager.GameState.Rhythm) return;

        GameManager.Instance.SettingGameState(DefineManager.GameState.Rhythm);


        ImageSizeBig();
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        instrumetnsObj.SetActive(true);

        CheckInstrumentsAndReadyRyhthm();
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
    }
}
