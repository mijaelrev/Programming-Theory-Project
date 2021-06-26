using UnityEngine;

namespace Code.ElementsManager
{
    public class SolidBlock : Block
    {
        [SerializeField] private float _maxVelocity = 20f;
        private void OnTriggerEnter(Collider other) => TriggerAction(other);
        protected override void TriggerAction(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (!other.TryGetComponent(out Rigidbody rigidBody)) return;
            if (rigidBody.velocity.y > _maxVelocity || rigidBody.velocity.y < -_maxVelocity) 
            {
                PlayerKill();
                Debug.Log("MUEREEEEEEEEEEEEEEEEEEE");
            }

        }
        internal override void CollisionAction(Collision collision)
        {
            return;
        }

        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("Solido Reciclado");

    }
}