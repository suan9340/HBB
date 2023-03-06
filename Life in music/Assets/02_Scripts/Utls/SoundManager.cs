using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleTon<SoundManager>
{

    [Header("--- LoopStation Source ---")]
    public List<LoopInfo> loopStationsources = new List<LoopInfo>();



    private int num = 0;

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
            _loop.source.clip = _clip;
        }
        else
        {

        }

    }

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
            loop.source.Play();
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

}

[Serializable]
public class LoopInfo
{
    public AudioSource source;
    public bool isOn;
}
