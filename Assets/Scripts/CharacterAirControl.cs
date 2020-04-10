using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAirControl : MonoBehaviour {
    public float maxSpeed = 5f;
    public float jumpVelocity = 20f;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool isGrounded;

    private Rigidbody2D rbody;

    private float movement;
    private bool jump;

    /* Input handling */
    private void OnMovement(InputValue value) =>
        movement = value.Get<float>();

    private void OnJump (InputValue value) =>
        jump = value.Get<float>() > 0f;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        rbody.gravityScale = 1;
    }

    private bool CanJump() {
        return isGrounded;
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void FixedUpdate() {
        var velocity = new Vector2(movement * maxSpeed, rbody.velocity.y);

        if (jump && CanJump())
            velocity.y = jumpVelocity;

        rbody.velocity = velocity;
    }
}
