using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTorque : MonoBehaviour
{
    public Vector2 intensity = new Vector2(5f, 15f);
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyRotation()
    {
        int direction = (Random.Range(0, 2) > 0) ? 1 : -1;
        _rb.AddTorque(direction * Random.Range(intensity.x, intensity.y));
    }
}
