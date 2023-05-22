using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaTuto : MonoBehaviour
{
    private Animator noteAnimation = null;
    private Rigidbody2D myrigid;
    private Transform mytrn;

    [Header("Umbrella Stand Obj")]
    public GameObject defaultObj = null;
    public GameObject changeObj = null;

    private void Start()
    {
        Cashing();
        AddForceObject();
    }


    private void Cashing()
    {
        noteAnimation = GetComponent<Animator>();
        myrigid = GetComponent<Rigidbody2D>();
        mytrn = GetComponent<Transform>();
    }

    private void AddForceObject()
    {
        myrigid.AddForce(-mytrn.position * 60f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        defaultObj.SetActive(false);
        changeObj.SetActive(true);
    }
}
