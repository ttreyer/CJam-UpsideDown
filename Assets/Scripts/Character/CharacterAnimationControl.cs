using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAnimationControl : MonoBehaviour
{
    [SerializeField] public bool isInWater = false;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.5f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _flip = false;
    private bool _isGrounded = true;
    private float _inputMovement;
    private bool _jump;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    /* Input handling */
    private void OnMovement(InputValue value) =>
        _inputMovement = value.Get<float>();

    private void OnJump(InputValue value) =>
        _jump = value.Get<float>() > 0f;

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, whatIsGround);
        
        _animator.SetFloat("velocity.x", Math.Abs(_inputMovement));
        _animator.SetBool("isJumping", _jump);
        _animator.SetFloat("velocity.y", _rb.velocity.y);
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetBool("isInWater", isInWater);
    }

    private void Update()
    { 
        if (_rb.velocity.x < -0.3f)
        {
            if (!_flip)
                transform.Rotate(Vector3.up, 180);

            _flip = true;
        }
        else if (_rb.velocity.x > 0.3f)
        {
            if (_flip)
                transform.Rotate(Vector3.up, 180);

            _flip = false;
        }
    }

    public void IsInWater(bool itIs) => isInWater = itIs;
}