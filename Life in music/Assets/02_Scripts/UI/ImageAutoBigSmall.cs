using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAutoBigSmall : MonoBehaviour
{
    private readonly WaitForSeconds delay = new WaitForSeconds(0.5f);

    private RectTransform rectTrn = null;

    private Vector3 bigVec = new Vector3(1.1f, 1.1f, 1.1f);
    private Vector3 defaultVec = new Vector3(1f, 1f, 1f);

    private void Start()
    {
        rectTrn = GetComponent<RectTransform>();

        StartCoroutine(ImageBigSmallCor());
    }

    private IEnumerator ImageBigSmallCor()
    {
        while (true)
        {
            Debug.Log("qwe");
            rectTrn.localScale = bigVec;
            yield return delay;
            rectTrn.localScale = defaultVec;
            yield return delay;
        }
    }
}
