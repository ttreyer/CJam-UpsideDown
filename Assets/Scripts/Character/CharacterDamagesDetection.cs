using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamagesDetection : MonoBehaviour
{
    [SerializeField] private float deadlyForce = 10.0f;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Deadly Item"))
        {
            var impact = (other.rigidbody.mass * other.relativeVelocity).magnitude;

            Debug.Log("impact: " + impact);

            if (impact >= deadlyForce)
            {
                Debug.Log("You're dead!");
            }
        }
    }
}
