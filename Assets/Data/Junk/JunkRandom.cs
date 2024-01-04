using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : QuangMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerCtrl();
    }
     

    protected virtual void LoadJunkSpawnerCtrl()
    {       
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + " : JunkSpawnerCtrl", gameObject);
    }
    
    protected virtual void FixedUpdate()
    {
        this.junkSpawning();
    }
    protected virtual void junkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;


        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform ranPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRamdom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

       
    }


    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
