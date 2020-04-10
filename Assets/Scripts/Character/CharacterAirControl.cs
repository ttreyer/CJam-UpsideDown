using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAirControl : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float jumpVelocity = 7f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public float coyoteTime = 0.1f;

    public LayerMask whatIsSlope;
    public Transform slopeCheck;
    public float slopeCheckRadius = 0.5f;

    public float waterJumpVelocity = 6.0f;
    public float waterJumpMinVRequired = 2.0f;
    
    private float lastGroundedTime;
    
    private Rigidbody2D rbody;
    private Animator animator;

    private float inputMovement;
    private float movement;
    private bool jump;
    private bool waterTransition;
    private bool isGrounded;

    /* Input handling */
    private void OnMovement(InputValue value) =>
        inputMovement = value.Get<float>();

    private void OnJump(InputValue value) =>
        jump = value.Get<float>() > 0f;

    /* Setup */
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        rbody.gravityScale = 1;
        waterTransition = true;
    }

    /* Jump & Movement */
    private bool CanJump() =>
        Time.time <= lastGroundedTime + coyoteTime;

    private void Update()
    {
        Debug.DrawLine(groundCheck.position, groundCheck.position + groundCheckRadius * Vector3.down);
        if (Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, whatIsGround))
            lastGroundedTime = Time.time;

        movement = inputMovement;
        Debug.DrawLine(slopeCheck.position, slopeCheck.position + slopeCheckRadius * Vector3.left);
        if (Physics2D.Raycast(slopeCheck.position, Vector2.left, slopeCheckRadius, whatIsSlope))
            movement = Mathf.Max(0f, movement);

        Debug.DrawLine(slopeCheck.position, slopeCheck.position + slopeCheckRadius * Vector3.right);
        if (Physics2D.Raycast(slopeCheck.position, Vector2.right, slopeCheckRadius, whatIsSlope))
            movement = Mathf.Min(0f, movement);
    }

    private void FixedUpdate()
    {
        var velocity = new Vector2(movement * maxSpeed, rbody.velocity.y);

        if (jump && CanJump())
            velocity.y = jumpVelocity;

        if(waterTransition && rbody.velocity.y > waterJumpMinVRequired)
        {
            velocity.y = waterJumpVelocity;
            waterTransition = false;
        }

        if (rbody.velocity.y < 0)
            velocity.y += Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        else if (!jump && rbody.velocity.y > 0)
            velocity.y += Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;

        rbody.velocity = velocity;
        animator.SetBool("isJumping", jump);
    }
}