using System;
using UnityEngine;

public class CharacterMiddleCheck : MonoBehaviour
{
    [SerializeField] private Transform waterSurfacePos;

    [SerializeField] private CharacterAirControl airControl;
    [SerializeField] private CharacterWaterControl waterControl;

    private Rigidbody2D rb;

    private void Start()
    {
        var isInWater = IsInWater();

        airControl.enabled = !isInWater;
        waterControl.enabled = isInWater;
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((IsInWater() && airControl.enabled) || (IsInTheAir() && waterControl.enabled))
        {
            ToggleControl();
        }
    }

    private void ToggleControl()
    {
        airControl.enabled = !airControl.enabled;
        waterControl.enabled = !waterControl.enabled;
    }

    private bool IsInWater()
    {
        return rb.position.y < waterSurfacePos.position.y;
    }

    private bool IsInTheAir()
    {
        return rb.position.y > waterSurfacePos.position.y;
    }
}