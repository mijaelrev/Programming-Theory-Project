using UnityEngine;

namespace Code.ElementsManager
{
    public class SolidBlock : Block
    {
        [SerializeField] private float _maxSpeed = 50f;
        private void Start()
        {
            Init();
        }
        private void OnCollisionEnter(Collision collision)
        {

            CollisionAction(collision);
        }

        protected override void TriggerAction(Collider other)
        {
            return;
        }
        internal override void CollisionAction(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            if (!collision.gameObject.TryGetComponent(out Rigidbody rigidBody)) return;
            if (rigidBody.velocity.y > _maxSpeed)
            {
                PlayerKill();
            }
        }

        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("Solido Reciclado");

    }
}