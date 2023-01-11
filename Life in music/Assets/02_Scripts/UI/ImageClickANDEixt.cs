using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClickANDEixt : ImageSizeInterface
    , IPointerClickHandler
    , IPointerExitHandler
{
    public  void OnPointerClick(PointerEventData eventData)
    {
        ImageSizeBig();
    }

    public  void OnPointerExit(PointerEventData eventData)
    {
        ImageSizeSmall();
    }
}
