using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmBaseNote : MonoBehaviour
{
    [Space(10)]
    [Header("Music")]
    public AudioSource audioSource = null; // ����� �ҽ� ���� 
    public AudioClip clip = null; // ����� Ŭ�� ����

    protected virtual void Start()
    {
        if (audioSource == null) // ����� �ҽ��� null �̸� ����� �ҽ��� �־��ش�.
        {
            audioSource = GameObject.Find("AudioSource (Rhythm)").GetComponent<AudioSource>();
            // ����� �ҽ��� ���� ������Ʈ���� �����´�.
        }

        audioSource.clip = clip; //����� �ҽ� Ŭ���� �ش� Ŭ���� �־��ش�.
    }

    public void StartMusic() // ������ �����Ѵ�.
    {
        audioSource.Play();
    }

    public void StopMusic() // ������ �����.
    {
        audioSource.Stop();
    }

    public void PauseMusic() //
    {
        audioSource.Pause();
    }
}
