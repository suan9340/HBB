using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectRhythmJudge : MonoBehaviour
{
    public RhythmCheck rhythmCheck = null;

    [Header("Texts")]
    public Text perfectTxt = null;
    public Text goodTxt = null;
    public Text badTxt = null;

    private void Start()
    {
        if (rhythmCheck == null)
        {
            rhythmCheck = Resources.Load<RhythmCheck>("SO/RhythmCheck");
        }
    }

    private void Update()
    {
        perfectTxt.text = $"{rhythmCheck.checkingNote[0].num}";
        goodTxt.text = $"{rhythmCheck.checkingNote[1].num}";
        badTxt.text = $"{rhythmCheck.checkingNote[2].num}";
    }
}
