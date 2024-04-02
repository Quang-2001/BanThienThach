using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilitySummonEnemy();
    }
    protected virtual void LoadAbilitySummonEnemy()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + " LoadAbilitySummonEnemy", gameObject);
    }
}
