using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : QuangMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints { get => junkSpawnPoints; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkSpawnPoints();
    }


    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner >();
        Debug.Log(transform.name + " : JunkSpawnerCtrl", gameObject); 
    }
    protected virtual void LoadJunkSpawnPoints()
    {
        if (this.junkSpawnPoints != null) return;
        this.junkSpawnPoints =Transform.FindObjectOfType<JunkSpawnPoints>();
        Debug.Log(transform.name + " : JunkSpawnPoints", gameObject);
    }
}
