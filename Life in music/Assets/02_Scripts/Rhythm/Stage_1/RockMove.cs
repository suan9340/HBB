using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockMove : MonoBehaviour
{
    private Rigidbody2D myrigid;
    private Transform mytrn;
    public float bulletSpeed;

    private void Start()
    {
        Cashing();
        AddForceObject();
    }

    private void FixedUpdate()
    {
        SettiingRotation();
    }

    private void Cashing()
    {
        myrigid = GetComponent<Rigidbody2D>();
        mytrn = GetComponent<Transform>();
    }

    private void AddForceObject()
    {
        myrigid.AddForce(-mytrn.position * bulletSpeed);
    }

    private void SettiingRotation()
    {
        float angle = Mathf.Atan2(myrigid.velocity.y, myrigid.velocity.x) * Mathf.Rad2Deg;
        mytrn.eulerAngles = new Vector3(0, 0, angle);
    }
}
