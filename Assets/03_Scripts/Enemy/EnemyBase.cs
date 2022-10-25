using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyInfo enemyInfo;

    public void Damaged(float _damage)
    {
        //Debug.Log($"Damaged!! // currentLife = {enemyInfo.life}");

        enemyInfo.life -= _damage;

        if (enemyInfo.life <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject} is DIE");
        gameObject.SetActive(false);
    }
}
