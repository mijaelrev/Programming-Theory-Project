using UnityEngine;

namespace Code.ElementsManager
{
    public class SolidBlock : Block
    {
        [SerializeField] private float _maxVelocity = 20f;
        [SerializeField] private int _timeClearValue = 200;
        private Vector3 _velocityValue;
        private void OnTriggerEnter(Collider other) => TriggerAction(other);
        private void OnCollisionEnter(Collision collision) => CollisionAction(collision);
        protected override void TriggerAction(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            var rigidbody = other.GetComponent<Rigidbody>();
            _velocityValue = rigidbody.velocity;
            ClearVelocity();
        }
        internal override void CollisionAction(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            if(_velocityValue.y > _maxVelocity || _velocityValue.y < -_maxVelocity )
            {
                PlayerKill();
            }

        }

        private async void ClearVelocity()
        {
            await System.Threading.Tasks.Task.Delay(_timeClearValue);
            _velocityValue = Vector3.zero;
        }
        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("Recycled SolidBlock");

    }
}