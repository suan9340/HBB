using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBigSmall : ImageSizeInterface
{
    public static readonly WaitForSeconds imageSpeed = new WaitForSeconds(0.3f);

    private Coroutine imageCoroutine;

    private void OnEnable()
    {
        StartCoroutine();
    }

    private void OnDisable()
    {
        StopCoroutine();
    }

    private void StartCoroutine()
    {
        imageCoroutine = StartCoroutine(ImageCoroutine());
    }

    private void StopCoroutine()
    {
        if (imageCoroutine != null)
        {
            StopCoroutine(imageCoroutine);
        }
    }


    private IEnumerator ImageCoroutine()
    {
        yield return null;

        for (int i = 0; i < 2; i++)
        {
            ImageSizeBig();

            yield return imageSpeed;

            ImageSizeSmall();

            yield return imageSpeed;
        }

        gameObject.SetActive(false);
        yield break;
    }
}
