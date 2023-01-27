using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickInstruments : ImageSizeInterface
     , IPointerClickHandler
    , IPointerExitHandler
{
    [Space(20)]
    public GameObject instrumetnsObj = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SettingGameState(DefineManager.GameState.Reythming);


        ImageSizeBig();
        EventManager.TriggerEvent(ConstantManager.START_RHYTHM);
        instrumetnsObj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ImageSizeSmall();
    }
}
