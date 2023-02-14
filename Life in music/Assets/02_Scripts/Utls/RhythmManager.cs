using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    public GameObject noteObject;
    public Vector3 pos;
    public float gap = 1;


    // Start is called before the first frame update
    void Start()
    {
        _data = RhythmData.LoadData("data1");

        _beatPerSec = 1f / RhythmData.BeatPerSec;
    }

    private RhythmData.MyData _data;
    private int _currentIndex = -5;
    private float _tick;
    private bool _hitCheck;
    private float _beatPerSec;

    // Update is called once per frame
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
                Debug.LogWarning("?�악??종료?�었??!");
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