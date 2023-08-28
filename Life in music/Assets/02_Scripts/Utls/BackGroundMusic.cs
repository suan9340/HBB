using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public AudioSource backgroundAudioSource;

    public void OnBackgroundSound()
    {
        backgroundAudioSource.Play();
      
    }

    public void OffBackgroundSound()
    {
        backgroundAudioSource.Stop();
    }
}
