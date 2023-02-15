using System.Collections.Generic;
using UnityEngine;

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
    private bool isData = false;

    private int currentIndex = 0;
    public float tick;
    private bool _hitCheck = false;
    private float beatPerSec;

    private bool isFirst = true;

    private void Update()
    {
        if (isData == false)
        {
            return;
        }


        tick += Time.deltaTime;
        if (tick >= beatPerSec)
        {
            tick -= beatPerSec;
            currentIndex++;
            if (currentIndex >= 0)
                _hitCheck = true;
        }

        if (_hitCheck)
        {
            _hitCheck = false;
            if (data.NoteList.Count <= currentIndex)
            {
                Debug.LogWarning("End");
            }
            else
            {
                for (int i = 0; i < data.BeatTrnCount; i++)
                {
                    var hit = data.NoteList[currentIndex][i];
                    if (hit)
                    {
                        if (isFirst)
                        {
                            isFirst = false;
                            var _obj2 = Instantiate(objList[1]);
                            _obj2.transform.SetParent(posList[i].transform, false);
                        }
                        else
                        {
                            var _obj = Instantiate(objList[i]);
                            _obj.transform.SetParent(posList[i].transform, false);
                        }
                        //pos = posList[i].transform.position;
                        //pos.x = i * gap;

                    }
                }
            }
        }
    }

    public void AddRhythmSO(string _name)
    {
        data = RhythmData.LoadData(_name);
        beatPerSec = 1f / data.BestPerSec;
        audioSource.clip = data.AudioClip;
        isData = true;
    }

    public void StartRhythmGame()
    {

        Debug.Log("qwe");
    }

    public void StopRhythm()
    {
        isData = false;
        currentIndex = -5;
        tick = 0;

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

    public void AddRhythmPosList(GameObject _trbobj, GameObject _obj)
    {
        posList.Add(_trbobj);
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