using System;
using UnityEngine;

public class PropsWaterDrawningPhysic : MonoBehaviour
{
    [SerializeField] private float gravityScale = .75f;
    private Rigidbody2D _rb;
    private float _velocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // _rb.velocity = new Vector2(_rb.velocity.x, _velocity);
    }

    private void OnEnable()
    {
        //_velocity = Math.Min(_rb.velocity.y / 2.0f, maxVelocity);
        _rb.drag = 30;
        _rb.gravityScale = gravityScale;
    }
}