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

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Y))
    //    {
    //        float _a = masterMixer.GetFloat("BGM");
    //    }
    //}

    public void OnAudioBGMControl(float _vol)
    {
        masterMixer.SetFloat("BGM", Mathf.Log10(_vol) * 20);
    }

    public void OnAudioSFXControl(float _vol)
    {
        masterMixer.SetFloat("SFX", Mathf.Log10(_vol) * 20);
    }
}
