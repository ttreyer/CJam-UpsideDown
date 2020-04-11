using UnityEngine;

namespace Character
{
    public class CheckpointChecker : MonoBehaviour
    {
        [SerializeField] private GameObject checkpoint;
        [SerializeField] private RoomRobin rr;

        private Rigidbody2D _rb;
        private bool _check = false;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (!_check && _rb.position.y > checkpoint.transform.position.y)
            {
                rr.PitchTo(-10.0f, 10.0f);
                _check = true;
            }
        }
    }
}
