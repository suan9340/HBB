using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Tmp : MonoBehaviour
{
    public AudioMixer masterMixer;

    [Header("Sliders")]
    public Slider BGMSlider;
    public Slider SFXSlider;

    private float remBgm = 1f;
    private float remSfx = 1f;


    private void Awake()
    {
        SettingSound();
    }

    private void OnDisable()
    {
        Remember();
    }

    public void OnAudioBGMControl(float _vol)
    {
        remBgm = _vol;
        masterMixer.SetFloat("BGM", Mathf.Log10(_vol) * 20);
    }

    public void OnAudioSFXControl(float _vol)
    {
        remSfx = _vol;
        masterMixer.SetFloat("SFX", Mathf.Log10(_vol) * 20);
    }

    private void Remember()
    {
        PlayerPrefs.SetFloat(ConstantManager.SOUND_BGM, remBgm);
        PlayerPrefs.SetFloat(ConstantManager.SOUND_SFX, remSfx);
    }

    private void SettingSound()
    {
        float _bb = PlayerPrefs.GetFloat(ConstantManager.SOUND_BGM, 1f);
        float _ss = PlayerPrefs.GetFloat(ConstantManager.SOUND_SFX, 1f);

        Debug.Log($"{_bb},   {_ss}");

        OnAudioBGMControl(_bb);
        OnAudioSFXControl(_ss);

        BGMSlider.value = _bb;
        SFXSlider.value = _ss;
    }
}
