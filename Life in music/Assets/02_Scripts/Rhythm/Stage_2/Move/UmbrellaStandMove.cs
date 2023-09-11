using UnityEngine;

public class UmbrellaStandMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private bool isStandNull;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "UmbrellaNote(Clone)")
        {

        }
    }
}