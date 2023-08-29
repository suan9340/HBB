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

    public void AudioCOntrol()
    {
        float _sound = BGMSlider.value;

        if (_sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", _sound);
    }

    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
