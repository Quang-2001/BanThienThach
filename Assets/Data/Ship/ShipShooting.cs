using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isshooting = false ;
    
    [SerializeField] protected float shootDelay =1f;
    [SerializeField] protected float shootTimer = 0f;

    private void Update()
    {
        this.Shooting();
    }
    private void FixedUpdate()
    {
        this.IsShooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isshooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newbullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newbullet == null) return;
        newbullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newbullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);

        Debug.Log("Shooting");
    }
    protected virtual bool IsShooting()
    {
        this.isshooting = InputManager.Instance.OnFiring == 1;
        return this.isshooting;
    }
    
}
