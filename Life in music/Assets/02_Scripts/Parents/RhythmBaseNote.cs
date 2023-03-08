using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmBaseNote : MonoBehaviour
{
    [Space(10)]
    [Header("Music")]
    public AudioSource audioSource = null; // 오디오 소스 정의 
    public AudioClip clip = null; // 오디오 클립 정의

    protected virtual void Start()
    {
        if (audioSource == null) // 오디오 소스가 null 이면 오디오 소스를 넣어준다.
        {
            audioSource = GameObject.Find("AudioSource (Rhythm)").GetComponent<AudioSource>();
            // 오디오 소스를 게임 오브젝트에서 가져온다.
        }

        audioSource.clip = clip; //오디오 소스 클립에 해당 클립을 넣어준다.
    }

    public void StartMusic() // 음악을 시작한다.
    {
        audioSource.Play();
    }

    public void StopMusic() // 음악을 멈춘다.
    {
        audioSource.Stop();
    }

    public void PauseMusic() //
    {
        audioSource.Pause();
    }
}
