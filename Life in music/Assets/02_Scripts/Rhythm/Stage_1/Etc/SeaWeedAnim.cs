using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SeaWeedAnim : MonoBehaviour
{
    public Animator myanim = null;

    private void OnEnable()
    {
        Cashing();
        Random();
    }

    private void Random()
    {
        var _rand = UnityEngine.Random.Range(0, 2);

        Debug.Log(_rand);

        if (_rand == 0)
        {
            myanim.SetTrigger("isSeaweedFishRight");
        }
        else
        {
            myanim.SetTrigger("isSeaweedFishLeft");
        }
    }

    private void Cashing()
    {
        if (myanim == null)
        {
            myanim = GetComponent<Animator>();
        }
    }
}
