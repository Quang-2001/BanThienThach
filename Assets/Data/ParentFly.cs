using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : QuangMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;
    //direction : huong bay


    private void Update()
    {
        transform.parent.Translate(this.moveSpeed * this.direction * Time.deltaTime);
    }
}
