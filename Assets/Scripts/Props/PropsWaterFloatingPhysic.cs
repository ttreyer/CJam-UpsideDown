using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsWaterFloatingPhysic : MonoBehaviour
{
    [SerializeField] private float acceleration = -2*Physics2D.gravity.y;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.AddForce(Vector2.up * (_rb.mass * acceleration));
    }
}
