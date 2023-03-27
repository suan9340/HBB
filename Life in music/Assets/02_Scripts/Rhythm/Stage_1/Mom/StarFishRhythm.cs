using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarFishRhythm : MonoBehaviour, IRhythmMom
{
    [Space(20)]
    [Header("--- StarFishNoteList ---")]
    public List<GameObject> starfishNoteObj = new List<GameObject>();

    [Space(20)]
    public GameObject starFIshImg = null;


    private void Awake()
    {
        NoteGen.Instance.IGenStarFish();
    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.STARFISH_ADD, AddNoteList);
        StartRhythm();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetUpStarfish();

            EventManager.TriggerEvent(ConstantManager.NOTE_LIST_REMOVE);
        }
    }

    private void StartRhythm()
    {
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_STARFISH);
        Invoke(nameof(StarFishMOM), 1.5f);
    }

    public void SetUpStarfish()
    {
        var _cnt = starfishNoteObj.Count;

        if (_cnt == 0)
        {
            Debug.Log("List Count is Zerooo");
            return;
        }

        var _starfishonjSelect = _cnt - 1;
        var _obj = starfishNoteObj[_starfishonjSelect].gameObject;

        _obj.GetComponent<StarFishMove>().StarfishDown();
        starfishNoteObj.Remove(_obj);
    }

    public void AddNoteList(GameObject _obj)
    {
        starfishNoteObj.Add(_obj);
    }

    private void StarFishMOM()
    {
        if (starFIshImg == null)
        {
            Debug.LogError("Starfish_Image is NULL!!!!");
            return;
        }

        starFIshImg.gameObject.SetActive(true);
    }
}
