using System;
using UnityEngine;

public class CharacterAnimationControl : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _flip = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_rb.velocity.x < -0.3f)
        {
            if(!_flip)
                transform.Rotate(Vector3.up, 180);
            
            _flip = true;
        }
        else if (_rb.velocity.x > 0.3f)
        {
            if(_flip)
                transform.Rotate(Vector3.up, 180);
            
            _flip = false;
        }
        
        _animator.SetFloat("velocity.x", Math.Abs(_rb.velocity.x));
        _animator.SetFloat("velocity.y", _rb.velocity.y);
    }
}
