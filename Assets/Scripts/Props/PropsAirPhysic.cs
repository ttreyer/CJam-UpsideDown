using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsAirPhysic : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.gravityScale = 1.0f;
    }
}
