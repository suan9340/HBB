using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    [Header("�������� �ݶ��̴�")]
    public BoxCollider col;


    [Header("�������� ������Ÿ��")]
    public float delayTime = 1f;

    private bool isHit = false;
    private void Start()
    {
        col = GetComponentInChildren<BoxCollider>();
    }

    private void Update()
    {
        InputKey();
    }


    /// <summary>
    /// Check User Mouse or KeyBoard Inputs
    /// </summary>
    private void InputKey()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }
    }

    /// <summary>
    /// Action MeleeAttack
    /// </summary>
    private void MeleeAttack()
    {
        if (isHit) return;
        isHit = true;

        col.enabled = true;
        Invoke(nameof(EndHitDelay), delayTime);
    }


    private void EndHitDelay()
    {
        col.enabled = false;
        isHit = false;
    }
}
