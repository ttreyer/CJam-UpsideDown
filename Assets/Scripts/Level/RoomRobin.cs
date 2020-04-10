using System;
using DG.Tweening;
using UnityEngine;

public class RoomRobin : MonoBehaviour
{
    [SerializeField] private float basicVelocity = 2.0f;

    private bool _isPitching;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isPitching)
            return;

        transform.eulerAngles += new Vector3(0, 0, basicVelocity * Time.fixedDeltaTime);
    }

    public void PitchTo(float targetAngle, float duration = 5.0f)
    {
        if (_isPitching)
            return;

        var angles = transform.eulerAngles;
        _isPitching = true;
        transform.DORotate(new Vector3(angles.x, angles.y, targetAngle), duration).SetEase(Ease.InOutElastic).OnComplete(ToggleIsPitching);
    }

    private void ToggleIsPitching() => _isPitching = !_isPitching;
}