using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterToggle : MonoBehaviour {
    public LayerMask whatIsWater;
    public UnityEvent onWaterEnter;
    public UnityEvent onWaterExit;

    private bool IsWater(GameObject other) =>
        (whatIsWater.value | other.layer) != 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (IsWater(collision.gameObject))
            onWaterEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (IsWater(collision.gameObject))
            onWaterExit.Invoke();
    }
}
