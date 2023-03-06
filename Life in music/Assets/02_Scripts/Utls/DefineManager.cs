using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefineManager
{
    public enum StageNames
    {
        Sea_01,
        School_02,
        PlayGround_03,
        Cafe_04,
        NONE,
    }


    public enum Stage_01_Inst
    {
        Starfish,
        Shellfish,
        Conch,
        Rock,
        Seaweed,
    }

    public enum GameState
    {
        Playing,
        Setting,
        Menu,
        Rhythm,
    }

    public enum Stage_01_MoveType
    {
        StarfishMove,
        ShellfishMove,
        ConchMove,
        RockMove,
        SeaweedMove,
    }

    public enum SoundManager
    {
        Rhythm_Click,
        Stage_Obj_UI,
        BGM,
        Metronom,
    }
}
