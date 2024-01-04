using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] protected Vector3 mouseworldPos;
    public Vector3 MouseworldPos  { get => mouseworldPos; }

    [SerializeField] protected float onFiring;
    public float OnFiring { get => onFiring; }



    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
        this.GetMouseDown();     
    }
    protected virtual void GetMousePos()
    {
        this.mouseworldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
