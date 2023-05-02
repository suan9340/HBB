using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaStandMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite UmbrellaStand01sprite;
    public Sprite UmbrellaStand02Sprite;

    public GameObject umbrellaStand;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.sprite = UmbrellaStand02Sprite;
    }

   public void SpriteChange()
    {
       spriteRenderer.sprite = UmbrellaStand01sprite;
    }

    private void Update()
    {
        //Test
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            spriteRenderer.sprite = UmbrellaStand01sprite;
        }
        
    }
}
