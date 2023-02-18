using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteManager : MonoSingleTon<NoteManager>
{
    public int bpm = 0;
    double currentTime = 0d;

    [Header("Sound")]
    [SerializeField] private AudioSource metronomeAudio = null;
    public AudioClip metronomClip = null;


    [Space(20)]
    [Header("Metronom")]
    [SerializeField] private List<GameObject> metrnomList = new List<GameObject>();
    private bool ismetrnom = false;

    private void Start()
    {
        if (metronomeAudio == null)
            Debug.LogError("metronomeAudio is null");

        if (metrnomList.Count == 0)
            Debug.LogError("metronomList is null");
    }

    private void Update()
    {
        BPMCheck();
    }

    private void BPMCheck()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            Debug.Log(currentTime);
            metronomeAudio.PlayOneShot(metronomClip);
            currentTime -= 60d / bpm;

            ChangeImage();
        }
    }

    private void ChangeImage()
    {
        ismetrnom = !ismetrnom;

        if(ismetrnom)
        {
            metrnomList[0].gameObject.SetActive(true);
            metrnomList[1].gameObject.SetActive(false);
        }
        else
        {
            metrnomList[0].gameObject.SetActive(false);
            metrnomList[1].gameObject.SetActive(true);
        }
    }
}
