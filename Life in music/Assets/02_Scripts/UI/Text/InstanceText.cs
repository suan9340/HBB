using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanceText : MonoBehaviour
{
    public RectTransform momObj = null;

    private void Start()
    {
        momObj = transform.GetChild(0).GetComponent<RectTransform>();

        EventManager<string>.StartListening(ConstantManager.NOTE_CHECKING_TXT, ShowTextObj);
    }

    public void ShowTextObj(string _s)
    {
        var _cnt = momObj.childCount;

        if (_cnt == 0)
        {
            Debug.LogError("child is ZZEERROOO");
            return;
        }

        var _obj = momObj.GetChild(0);
        _obj.GetComponent<NoteTextAnimation>().SettingEnum(_s);
        _obj.gameObject.SetActive(true);
    }
}
