using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageEnterANDExit : ImageSizeInterface
    , IPointerEnterHandler
    , IPointerExitHandler
{
    public  void OnPointerEnter(PointerEventData eventData)
    {
        ImageSizeBig();
    }

    public  void OnPointerExit(PointerEventData eventData)
    {
        ImageSizeSmall();
    }
}
