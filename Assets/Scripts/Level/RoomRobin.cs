using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRobin : MonoBehaviour
{
    private float _velocity = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0,  transform.eulerAngles.z + _velocity * Time.fixedDeltaTime);
    }

    public void SetVelocity(float velocity)
    {
        _velocity = velocity;
    }
}
