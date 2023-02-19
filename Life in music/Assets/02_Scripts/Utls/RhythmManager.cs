using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class RhythmManager : MonoSingleTon<RhythmManager>
{
    private Vector3 pos;
    //public float gap = 1;
    public AudioSource audioSource;

    [Space(20)]
    [Header("Rhythm Position List")]
    public List<GameObject> posList = new List<GameObject>();

    [Space(20)]
    [Header("Rhythm Object List")]
    public List<GameObject> objList = new List<GameObject>();

    public RhythmData.MyData data;

    private int currentIndex = 0;

    private float currentTime = 0f;
    private float beatPerSec = 0;

    private bool isFirst = true;
    private bool isRhythm = false;

    private void Update()
    {
        if (isRhythm == false)
        {
            return;
        }
        else
        {
            CheckNoteANDInstantiate();
        }

    }

    private void CheckNoteANDInstantiate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60f / (data.Bpm * data.BestPerSec))
        {
            for (int i = 0; i < data.BeatTrnCount; i++)
            {
                var _hit = data.NoteList[currentIndex][i];

                if (_hit)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        var _obj2 = Instantiate(objList[objList.Count - 1]);
                        _obj2.transform.SetParent(posList[i].transform, false);
                    }
                    else
                    {
                        var _obj = Instantiate(objList[i]);
                        _obj.transform.SetParent(posList[i].transform, false);
                    }
                }
                //Debug.Log(currentTime);
            }
            currentIndex++;
            currentTime -= 60f / (data.Bpm * data.BestPerSec);
        }
    }


    public void ReadyRhythm(string _name)
    {
        data = RhythmData.LoadData(_name);
        beatPerSec = 1f / data.BestPerSec;
        audioSource.clip = data.AudioClip;

        Invoke(nameof(StartRhythmGame), 1.4f);
    }

    public void StartRhythmGame()
    {
        isRhythm = true;
    }

    public void StopRhythm()
    {
        isRhythm = false;

        currentIndex = -5;

        data.name = null;
        data.AudioClip = null;
        data.Bpm = 0;
        data.BeatTrnCount = 0;
        data.BestPerSec = 0;
        data.NoteList = null;

        posList.Clear();
        objList.Clear();

        audioSource.clip = null;
    }

    public void SettingRhythmPosition(GameObject _trbobj)
    {
        posList.Add(_trbobj);
    }

    public void SettingRhythmObject(GameObject _obj)
    {
        objList.Add(_obj);
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void EndMusic()
    {
        audioSource.Stop();
    }


   
}