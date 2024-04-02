using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Abilities Summon ")]
    [SerializeField] protected Spawner spawner;
    

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }
    protected virtual void Summoning()
    {
        if (!this.isRead) return;
        this.Summon();

    }
    protected virtual void Summon()
    {
        Transform spawnPos = this.abilites.AbilityObjectCtrl.SpawnPoints.GetRamdom();

        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, spawnPos.position, spawnPos.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
    }

}
