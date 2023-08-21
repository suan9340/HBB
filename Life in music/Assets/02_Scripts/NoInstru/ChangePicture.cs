using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePicture : MonoBehaviour
{
    private SpriteRenderer mySprite = null;

    public Sprite[] Sprites;

    private readonly WaitForSeconds second = new WaitForSeconds(1);

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeCor());
    }

    private IEnumerator ChangeCor()
    {
        while (true)
        {
            mySprite.sprite = Sprites[0];
            yield return second;
            mySprite.sprite = Sprites[1];
            yield return second;
        }
    }
}
