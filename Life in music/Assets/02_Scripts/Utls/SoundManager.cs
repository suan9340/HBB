using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleTon<SoundManager>
{

    [Header("--- LoopStation Source ---")]
    public List<LoopInfo> loopStationsources = new List<LoopInfo>();


    public int num = 1;

    private readonly WaitForSeconds soundSec = new WaitForSeconds(0.05f);

    private bool isFadeIn, isFadeOut = false;

    private void Start()
    {
        PlayLoopSource(1f);
        EventManager<float>.StartListening(ConstantManager.RHYTHM_SOUND_START, GoGoSound);
    }


    public void GoGoSound(float _vol)
    {
        PlayLoopSource(_vol);
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


    public void PlayLoopSource(float _vol)
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];

            if (loop.isOn)
            {
                //Debug.Log($"{i} �� ������");
                loop.source.Play();
                StartCoroutine(FadeInMusic(loop.source, _vol));
            }
        }
    }

    public void StopLoopSource()
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];
            //loop.source.Stop();
            StartCoroutine(FadeOutMusic(loop.source));
        }
    }

    private IEnumerator FadeOutMusic(AudioSource _source)
    {
        isFadeOut = true;

        while (true)
        {
            if (_source.volume <= 0)
            {
                isFadeOut = false;
                _source.volume = 0;
                _source.Stop();
                yield break;
            }
            _source.volume -= Time.deltaTime * 3f;
            yield return soundSec;
        }

    }

    private IEnumerator FadeInMusic(AudioSource _source, float _vol)
    {
        isFadeIn = true;
        _source.Play();

        while (true)
        {
            if (_source.volume >= _vol)
            {
                _source.volume = _vol;
                isFadeIn = false;
                yield break;
            }
            _source.volume += Time.deltaTime * 3f;
            //Debug.Log(_source.volume);
            yield return soundSec;
        }
    }

    public void STOPingMusic()
    {
        for (int i = 0; i < num; i++)
        {
            var loop = loopStationsources[i];
            loop.source.Stop();
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
