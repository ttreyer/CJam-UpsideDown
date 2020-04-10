using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterWaterControl : MonoBehaviour
{
    [SerializeField] private float waterGravityScaleSwim = 0.5f;
    [SerializeField] private float swimVelocity = 3.0f;
    [SerializeField] private float drownVelocity = 2.0f;
    [SerializeField] private float sideVelocity = 3.0f;

    private Rigidbody2D _rb;
    private bool _swim = false;
    private bool _isSwimming = false;
    private float _horizontalAxis = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (_swim)
        {
            _rb.velocity = Vector2.up * swimVelocity;
            _isSwimming = true;
            _swim = false;

            _rb.gravityScale = waterGravityScaleSwim;
        }
        else if (_isSwimming && _rb.velocity.y < drownVelocity / -2.0f)
        {
            _isSwimming = false;
            _rb.gravityScale = .0f;
        }
        else if (!_isSwimming)
        {
            _rb.velocity = Vector2.down * drownVelocity;
        }


        _rb.velocity = new Vector2(_horizontalAxis * sideVelocity, _rb.velocity.y);
    }

    private void OnMovement(InputValue value)
    {
        _horizontalAxis = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        _swim = value.Get<float>() > 0;
    }
}