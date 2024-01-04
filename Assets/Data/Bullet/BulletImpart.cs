using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigibody();
    }


    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + "LoadSphereCollider", gameObject);

    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + "LoadRigibody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.parent.name);
        Debug.Log(transform.parent.name);
        if (other.transform.parent == transform.parent) return;
        this.bulletCtrl.DamageSender.Send(other.transform);
        this.CreatImpactFX();
    }
    protected virtual void CreatImpactFX()
    {

        string fxname = this.GetImpactFX();
        Vector3 hitPos = transform.position;
        Quaternion hitRos = transform.rotation;

         Transform fxImpact = FXSpawner.Instance.Spawn(fxname, hitPos, hitRos);
        fxImpact.gameObject.SetActive(true);

    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }

}

