using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoMOM : MonoBehaviour
{
    protected Animator myAnim = null;
    protected AudioSource mySource = null;
    protected bool isClick = false;

    public AudioClip myClip = null;
    public int loadnum;

    protected virtual void Start()
    {
        myAnim = GetComponent<Animator>();
        mySource = GameObject.FindGameObjectWithTag("rhythmTutoSound").GetComponent<AudioSource>();
    }


}
