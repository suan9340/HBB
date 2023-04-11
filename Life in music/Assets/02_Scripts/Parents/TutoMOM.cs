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

    [Space(20)]
    [Header("--- StarFishNoteList ---")]
    public List<GameObject> noteObjList = new List<GameObject>();


    [Space(20)]
    [Header("--- TutoObj ---")]
    public List<String> tutoTxt = new List<String>();
    public List<GameObject> tutoObj = new List<GameObject>();
    [Header("-----------------")]

    protected int tutoNum = 0;
    protected bool isTuto = false;

    protected virtual void Start()
    {
        myAnim = GetComponent<Animator>();
        mySource = GameObject.FindGameObjectWithTag("rhythmTutoSound").GetComponent<AudioSource>();
    }


}
