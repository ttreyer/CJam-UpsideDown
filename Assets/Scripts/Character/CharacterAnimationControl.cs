using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAnimationControl : MonoBehaviour
{
    [SerializeField] public bool isInWater = false;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.5f;
    [SerializeField] private float waterTildAngle = 45.0f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _flip = false;
    private bool[] _tildLR = new[] {true, true};
    private bool _isGrounded = true;
    private float _inputMovement;
    private bool _jump;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
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
        Vector3 newAngles = transform.eulerAngles;
        
        if (_rb.velocity.x < -0.3f)
        {
            if (isInWater && _tildLR[1])
            {
                //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, waterTildAngle);
                newAngles.z = -waterTildAngle;
            }
            
            if (!_flip)
            {
                //transform.Rotate(Vector3.up, 180);
                newAngles.y += 180;
                _flip = true;
            }
        }
        else if (_rb.velocity.x > 0.3f)
        {
            if (isInWater && _tildLR[0])
            {
                //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -waterTildAngle);
                newAngles.z = -waterTildAngle;
            }
            
            if (_flip)
            {
                //transform.Rotate(Vector3.up, 180);
                newAngles.y += 180;
                _flip = false;
            }
        }
        else if (_tildLR.Any())
        {
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            newAngles.z = 0;
        }

        if (_isGrounded || !isInWater)
        {
            newAngles.z = 0;
        }

        transform.rotation = Quaternion.Euler(newAngles);
    }

    public void IsInWater(bool itIs) => isInWater = itIs;
}