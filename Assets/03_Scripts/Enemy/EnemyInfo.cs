using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyInfo
{
    public EnemyTypes enemyTypes;
    public string name;
    public float life;
}

public enum EnemyTypes
{
    Enemy1,
    Enemy2,
    Enemy3,
}