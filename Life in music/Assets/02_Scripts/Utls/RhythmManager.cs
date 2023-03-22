using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class RhythmManager : MonoSingleTon<RhythmManager>
{
    private Vector3 pos;
    //public float gap = 1;
    public AudioSource audioSource;

    public RhythmData.MyData data;
    private CurrnetstageSO currentStage;


    [Space(20)]
    [Header("Current Rhythm")]
    public GameObject curRhy;

    private int currentIndex = 0;

    private float currentTime = 0f;
    private float beatPerSec = 0;

    private bool isRhythm = false;

    private void Start()
    {
        if (currentStage == null)
        {
            currentStage = Resources.Load<CurrnetstageSO>("SO/CurrentstageSO");
        }
    }

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

         //   Debug.Log($"{currentIndex}  /  {data.NoteList.Count}");


            if (currentIndex >= data.NoteList.Count)
            {
                StopRhythm();
                Debug.Log("ENd!!!!!!");
                SoundManager.Instance.StopLoopSource();
                isRhythm = false;

                StartCoroutine(GoHomeYPlayMusic());
                return;
            }
            else
            {
                var listBool = data.NoteList[currentIndex];
                EventManager<List<bool>>.TriggerEvent(ConstantManager.BEAT, listBool.beatFlag);
                currentIndex++;
                currentTime -= 60f / (data.Bpm * data.BestPerSec);
            }
        }
    }


    /// <summary>
    /// Starting Rhythm Notes 1.4ÃÊ µÚ¿¡
    /// </summary>
    /// <param name="_name"></param>
    public void ReadyRhythm(string _name)
    {
        data = RhythmData.LoadData(_name);
        beatPerSec = 1f / data.BestPerSec;
        audioSource.clip = data.AudioClip;

        Invoke(nameof(StartRhythmGame), 1.5f);
    }

    public void StartRhythmGame()
    {
        isRhythm = true;
    }

    public void StopRhythm()
    {
        Destroy(curRhy.gameObject);

        isRhythm = false;

        currentIndex = 0;

        //data.name = null;
        //data.AudioClip = null;
        //data.Bpm = 0;
        //data.BeatTrnCount = 0;
        //data.BestPerSec = 0;
        //data.NoteList = null;
        //curRhy = null;

        //objList.Clear();

        audioSource.clip = null;
    }


    //public void SettingRhythmObject(GameObject _obj)
    //{
    //    objList.Add(_obj);
    //}

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void EndMusic()
    {
        audioSource.Stop();
    }

    private void CheckStopRhythm()
    {
        if (currentIndex >= data.NoteList.Count)
        {
            StopRhythm();
            EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        }
    }


    public void SettingCurRhythm(GameObject _obj)
    {
        curRhy = _obj;
    }

    private IEnumerator GoHomeYPlayMusic()
    {
        yield return new WaitForSeconds(3f);
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        SoundManager.Instance.CheckYOnAudio(currentStage.clip);


        EventManager.TriggerEvent(ConstantManager.RHYTHM_SOUND_START);
        ChatMaanger.Instance.Text();
        yield break;
    }
}