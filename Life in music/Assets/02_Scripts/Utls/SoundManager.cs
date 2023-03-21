using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleTon<SoundManager>
{

    [Header("--- LoopStation Source ---")]
    public List<LoopInfo> loopStationsources = new List<LoopInfo>();

    public AudioSource rhythmAudio = null;

    public int num = 1;


    private void Start()
    {
        GoGoSound();
        EventManager.StartListening(ConstantManager.RHYTHM_SOUND_START, GoGoSound);
    }


    public void GoGoSound()
    {
        //Debug.Log("SoundMusic");
        StopLoopSource();
        PlayLoopSource();
    }
    public void CheckYOnAudio(AudioClip _clip)
    {
        if (loopStationsources == null)
        {
            Debug.Log("LoopStationSource is NULL!!");
            return;
        }


        var _loop = loopStationsources[num];

        if (GetBoolYCheck(_loop))
        {
            loopStationsources[num].isOn = true;
            _loop.source.clip = _clip;
            num++;
        }
        else
        {
            GetBoolYCheck(_loop);
        }
    }

    /// <summary>
    /// if false, cant clip, true can clip
    /// </summary>
    /// <param name="_info"></param>
    /// <returns></returns>
    private bool GetBoolYCheck(LoopInfo _info)
    {
        if (_info.isOn)
        {
            num++;
            return false;
        }
        else
        {
            return true;
        }
    }


    public void PlayLoopSource()
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];

            if (loop.isOn)
            {
                Debug.Log($"{i} 개 실행중");
                loop.source.Play();
            }
        }
    }

    public void StopLoopSource()
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];
            loop.source.Stop();
        }
    }

    public void ResetMusic()
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];
            loop.isOn = false;
            loop.source.clip = null;
        }
    }

    public void VolumeRhythmSettingDown(float _vol)
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];
            loop.source.volume = _vol;
        }
    }

    public void VolumeReturn()
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];
            loop.source.volume = 1f;
        }
    }
}

[Serializable]
public class LoopInfo
{
    public AudioSource source;
    public bool isOn;
}
