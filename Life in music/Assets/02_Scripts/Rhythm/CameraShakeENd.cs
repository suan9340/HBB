using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeENd : MonoBehaviour
{
    private Camera myCam = null;


    private readonly WaitForSeconds camSec = new WaitForSeconds(1);
    private void Start()
    {
        myCam = Camera.main;
        EventManager.StartListening(ConstantManager.END_CAM_SHAKE, StartCameraShaking);
    }

    private void OnDisable()
    {
        EventManager.StopListening(ConstantManager.END_CAM_SHAKE, StartCameraShaking);
    }

    private void StartCameraShaking()
    {
        StartCoroutine(CamIII());
    }

    private IEnumerator CamIII()
    {
        while (true)
        {
            myCam.orthographicSize = 4.8f;
            yield return camSec;
            myCam.orthographicSize = 5f;
            yield return camSec;
        }
    }
}
