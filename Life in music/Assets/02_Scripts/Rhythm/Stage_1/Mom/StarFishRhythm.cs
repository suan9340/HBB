using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;


public class StarFishRhythm : MonoBehaviour, IRhythmMom
{
    [Space(20)]
    [Header("--- StarFishNoteList ---")]
    public List<GameObject> starfishNoteObj = new List<GameObject>();

    [Space(20)]
    public GameObject Starfish_Image;


    private void Awake()
    {
        NoteGen.Instance.IGenStarFish();

    }

    private void Start()
    {
        EventManager<GameObject>.StartListening(ConstantManager.STARFISH_ADD, AddNoteList);
        RhythmManager.Instance.ReadyRhythm(ConstantManager.SO_STAGE01_STARFISH);

        Invoke(nameof(StarFishStart), 2f);
    }

   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
                SetUpStarfish();
            }
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

        Debug.Log(_cnt);
    }



    public void AddNoteList(GameObject _obj)
    {
 
        starfishNoteObj.Add(_obj);
    }

    private void StarFishStart()
    {
        if (Starfish_Image == null)
        {
            Debug.LogError("Starfish_Image is NULL!!!!");
            return;
        }
        Starfish_Image.gameObject.SetActive(true);
    }
}
