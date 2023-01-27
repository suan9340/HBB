using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageSizeInterface : MonoBehaviour
{
    public Vector3 sizeVec = new Vector3(0.1f, 0.1f, 0.1f);

    private Vector3 lastScale = Vector3.zero;
    private bool isScaleBig = false;

    [Header("AudioSound")]
    public AudioSource effectAudio = null;
    public AudioClip clip = null;

    protected  void Start()
    {
        SetScale(transform.localScale);
    }

    #region Images_Fuction

    protected void ImageSizeBig()
    {
        if (isScaleBig) return;
        isScaleBig = true;

        if (effectAudio != null && clip != null)
        {
            effectAudio.PlayOneShot(clip);
        }

        SetScale(transform.localScale);
        transform.localScale += sizeVec; 
    }

    protected void ImageSizeSmall()
    {
        isScaleBig = false;
        transform.localScale = GetScale();
    }

    private void SetScale(Vector3 _vec)
    {
        lastScale = _vec;
    }

    private Vector3 GetScale()
    {
        return lastScale;
    }

    #endregion
}
