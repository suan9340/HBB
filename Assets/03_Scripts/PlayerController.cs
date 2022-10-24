using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myrigid;
    private bool isJump = false;

    [Header("MoveSpeed")]
    [Range(0f, 50f)]
    public float moveSpeed = 3f;

    [Header("JumpPower")]
    public float jumpPower = 2f;


    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    /// <summary>
    /// Player Left,Right Movement 
    /// </summary>
    private void PlayerMove()
    {
        var _ho = Input.GetAxisRaw("Horizontal");
        Vector3 _newDir = transform.position;

        _newDir.x += _ho * Time.deltaTime * moveSpeed;
        _newDir.z = 0f;


        PlayerRotation(_ho);
        transform.position = _newDir;
    }

    /// <summary>
    /// Player Rotation
    /// </summary>
    /// <param name="_ho"></param>
    private void PlayerRotation(float _ho)
    {
        if (_ho == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (_ho == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }


    /// <summary>
    /// PlayerJumping
    /// </summary>
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump) return;
            isJump = true;

            myrigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isJump = false;
        }
    }
}
