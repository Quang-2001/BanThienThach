using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : QuangMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected Abilites abilites;
    public Abilites Abilites => abilites;

    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isRead = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilites();
    }
    protected virtual void LoadAbilites()
    {
        if (this.abilites != null) return;
        this.abilites = transform.parent.GetComponent<Abilites>();
        Debug.Log(transform.name + " LoadAbilites", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Timing()
    {
        if (this.isRead) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isRead = true;
    }

    public virtual void Active()
    {
        this.isRead = false;
        this.timer = 0;
    }
}
