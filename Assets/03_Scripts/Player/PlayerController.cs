using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myrigid;
    private Renderer render;
    private bool isJump = false;

    [Header("MoveSpeed")]
    [Range(0f, 50f)]
    public float moveSpeed = 3f;

    [Header("JumpPower")]
    public float jumpPower = 2f;

    [Header("Enemey Bound Power")]
    public float bouncePower;

    [Header("Player Life")]
    public float playerLife;

    [Header("PlayerDamaged ChangeColor Alpha")]
    public float alphaColr;

    public Color changeColor;
    private Color defaultColor;

    private bool isDamaged = false;

    private readonly WaitForSeconds damageSpriteTime = new WaitForSeconds(0.15f);
    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
        render = GetComponentInChildren<Renderer>();



        defaultColor = render.material.color;
        changeColor.a = alphaColr;
    }

    private void Update()
    {
        if (isDamaged) return;

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

    /// <summary>
    /// Player Damaged from Enemy
    /// </summary>
    private IEnumerator Damaged(Vector3 _targetPos)
    {
        if (isDamaged) yield break;
        isDamaged = true;

        playerLife--;


        int _dirc = transform.position.x - _targetPos.x > 0 ? 1 : -1;
        myrigid.AddForce(new Vector3(_dirc, 1f, 0f) * bouncePower, ForceMode.Impulse);

        for (int i = 0; i < 4; i++)
        {
            yield return damageSpriteTime;
            render.material.color = changeColor;
            yield return damageSpriteTime;
            render.material.color = defaultColor;
        }

        yield break;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isJump = false;
            isDamaged = false;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            StartCoroutine(Damaged(collision.transform.position));
        }
    }
}
