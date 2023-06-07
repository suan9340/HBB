using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaking : MonoBehaviour
{
    public float duration = 1.0f;
    public float strength = 0.1f;
    public int vibrato = 90;


    public void Start()
    {
        EventManager.StartListening(ConstantManager.CAMERA_SHAKE, Shaking);
    }

    private void OnDisable()
    {
        EventManager.StopListening(ConstantManager.CAMERA_SHAKE, Shaking);
    }

    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Shaking();
    //    }
    //}

    private void Shaking()
    {
        Camera.main.DOShakePosition(duration, strength, vibrato);
    }
}
