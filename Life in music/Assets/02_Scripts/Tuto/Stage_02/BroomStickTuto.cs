using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomStickTuto : MonoBehaviour
{
    private Animator myAnim;

    private readonly WaitForSeconds broomsec = new WaitForSeconds(0.4f);

    public AudioSource source = null;
    public AudioClip clip = null;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        source = GameObject.FindGameObjectWithTag("rhythmTutoSound").GetComponent<AudioSource>();

        StartCoroutine(Cor());

        if (clip == null)
        {
            Debug.LogError("clip is NULL!");
        }
    }

    private IEnumerator Cor()
    {
        myAnim.SetTrigger("BroomStickShow");
        yield return broomsec;
        source.PlayOneShot(clip);

        myAnim.SetTrigger("BroomStickClick");
        yield return new WaitForSeconds(1.3f);
        source.PlayOneShot(clip);

        yield break;
    }

}
