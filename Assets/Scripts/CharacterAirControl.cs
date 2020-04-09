using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAirControl : MonoBehaviour {
    public float maxSpeed = 5f;

    private Rigidbody2D rbody;

    private float movement;
    private bool jump;

    public void OnMovement(InputValue value) {
        movement = value.Get<float>();
    }

    public void OnJump(InputValue value) {
        Debug.Log(value.Get<float>());
    }

    private void Awake() {
        //rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        rbody.gravityScale = 1;
    }

}
