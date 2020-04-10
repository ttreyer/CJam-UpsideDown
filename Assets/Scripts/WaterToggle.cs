using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterToggle : MonoBehaviour {
    public UnityEvent onWaterEnter;
    public UnityEvent onWaterExit;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Water")
            onWaterEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Water")
            onWaterExit.Invoke();
    }
}
