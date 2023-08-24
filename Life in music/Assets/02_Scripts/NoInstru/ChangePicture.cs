using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePicture : MonoBehaviour
{
    private SpriteRenderer mySprite = null;

    public Sprite[] chSprite;

    private int spriteNum = 0;
    private readonly WaitForSeconds second = new WaitForSeconds(1);

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        spriteNum = chSprite.Length;
        StartCoroutine(ChangeCor());
    }

    private void OnDisable()
    {
        StopCoroutine(ChangeCor());
    }

    private IEnumerator ChangeCor()
    {
        while (true)
        {
            for (int i = 0; i < spriteNum; i++)
            {
                yield return second;
                mySprite.sprite = chSprite[i];
            }
        }
    }
}
