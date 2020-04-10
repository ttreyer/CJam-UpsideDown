using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyancy : MonoBehaviour {
    public float magnitude = 10f;
    private Rigidbody2D rbody;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        rbody.velocity /= 2f;
        rbody.drag = 5f;
        rbody.angularDrag = 5f;
    }

    private void OnDisable() {
        rbody.drag = 0f;
        rbody.angularDrag = 0.05f;
    }

    private void FixedUpdate() =>
        rbody.AddForce(Vector2.up * magnitude);
}
