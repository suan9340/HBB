using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    private AudioSource myAudio = null;
    private bool ismusicStart = false;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!ismusicStart)
        {
            if (collision.CompareTag("Note"))
            {
                myAudio.Play();
                ismusicStart = true;
            }
        }
    }
}
