using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRocking : MonoBehaviour {
    public Vector2 rockingBoundaries = new Vector2(-30f, 30f);
    public float speed = 2f;
    [Range(0, Mathf.PI)]
    public float startOffset = 0f;

    private float startTime;

    private void Awake() {
        startTime = Time.time + startOffset;
    }

    private float RemapRange(float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    private void FixedUpdate() {
        float t = Time.time - startTime;
        float rock = Mathf.Sin(t * speed);
        float angle = RemapRange(rock, -1f, 1f, rockingBoundaries.x, rockingBoundaries.y);

        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
