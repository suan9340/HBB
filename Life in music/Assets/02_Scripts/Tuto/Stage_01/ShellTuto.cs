using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellTuto : MonoBehaviour
{
    private Animator myAnim = null;
    public AudioClip myClip = null;
    private AudioSource mySource = null;

    private bool isClick = false;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        mySource = GameObject.FindGameObjectWithTag("rhythmTutoSound").GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isClick) return;

            isClick = true;
            myAnim.SetTrigger("isDown");
            mySource.PlayOneShot(myClip);
        }
    }

}
