using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmMusicBase : MonoBehaviour
{
    [Space(10)]
    [Header("Music")]
    public AudioSource audioSource = null;
    public AudioClip clip = null;

    protected virtual void Start()
    {
        if (audioSource == null)
        {
            audioSource = GameObject.Find("AudioSource (Rhythm)").GetComponent<AudioSource>();
        }

        audioSource.clip = clip;
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }
}
