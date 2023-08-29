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

    public void OnAudioBGMControl()
    {
        float _sound = BGMSlider.value;

        if (_sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", _sound);
    }

    public void OnAudioSFXControl()
    {
        float _so = SFXSlider.value;

        if (_so == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", _so);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
