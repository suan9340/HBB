using UnityEngine;

public class UmbrellaStandMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite UmbrellaStand01sprite;
    public Sprite UmbrellaStand02Sprite;

    private bool isStandNull;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "UmbrellaNote(Clone)")
        {
            //isStandNull = true;
            spriteRenderer.sprite = UmbrellaStand01sprite;
        }
    }


    public void SpriteChange()
    {
     //  isStandNull = false;
        spriteRenderer.sprite = UmbrellaStand02Sprite;
    }

    private void Update()
    {
       // if (isStandNull)
        {
            
        }
      //  else
        {
            
        }
    }
}
