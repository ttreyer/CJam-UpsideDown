using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAirControl : MonoBehaviour {
    public float maxSpeed = 5f;
    public float jumpVelocity = 7f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius = 0.25f;
    public float coyoteTime = 0.1f;
    private float lastGroundedTime;

    private Rigidbody2D rbody;

    private float movement;
    private bool jump;

    /* Input handling */
    private void OnMovement(InputValue value) =>
        movement = value.Get<float>();

    private void OnJump (InputValue value) =>
        jump = value.Get<float>() > 0f;


    /* Setup */
    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        rbody.gravityScale = 1;
    }

    /* Jump & Movement */
    private bool CanJump() =>
        Time.time <= lastGroundedTime + coyoteTime;

    private void Update() {
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround))
            lastGroundedTime = Time.time;
    }

    private void FixedUpdate() {
        var velocity = new Vector2(movement * maxSpeed, rbody.velocity.y);

        if (jump && CanJump())
            velocity.y = jumpVelocity;

        if (rbody.velocity.y < 0)
            velocity.y += Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        else if (!jump && rbody.velocity.y > 0)
            velocity.y += Physics2D.gravity.y * (lowJumpMultiplier - 1f) * Time.deltaTime;

        rbody.velocity = velocity;
    }
}
