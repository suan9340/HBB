using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaStandMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite UmbrellaStand01sprite;
    public Sprite UmbrellaStand02Sprite;
   

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
          
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.sprite = UmbrellaStand02Sprite;
    }

   public void SpriteChange()
    {
        spriteRenderer.sprite = UmbrellaStand01sprite;
    }
}
