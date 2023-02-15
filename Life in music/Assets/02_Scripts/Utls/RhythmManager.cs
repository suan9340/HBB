using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public GameObject noteObject;
    public Vector3 pos;
    public float gap = 1;

    [Space(20)]
    [Header("Rhythm Position List")]
    public List<GameObject> list = new List<GameObject>();

    private RhythmData.MyData _data;
    private int _currentIndex = -5;
    private float _tick;
    private bool _hitCheck;
    private float _beatPerSec;

    void Start()
    {
        _data = RhythmData.LoadData("data1");

        _beatPerSec = 1f / RhythmData.BeatPerSec;
    }

    void Update()
    {
        _tick += Time.deltaTime;
        if (_tick >= _beatPerSec)
        {
            _tick -= _beatPerSec;
            _currentIndex++;
            if (_currentIndex >= 0)
                _hitCheck = true;
        }

        if (_hitCheck)
        {
            _hitCheck = false;
            if (_data.NoteList.Count <= _currentIndex)
            {
                Debug.LogWarning("End");
            }
            else
            {
                for (int i = 0; i < _data.BeatCount; i++)
                {
                    var hit = _data.NoteList[_currentIndex][i];
                    if (hit)
                    {
                        pos.x = i * gap;
                        Instantiate(noteObject, pos, Quaternion.identity);
                    }
                }
            }
        }
    }
}