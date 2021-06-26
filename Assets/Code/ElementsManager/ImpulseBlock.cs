using UnityEngine;

namespace Code.ElementsManager
{
    public class ImpulseBlock : Block
    {
        [SerializeField] private float _force = 15f;
        private Vector3 _direction;

        private void OnTriggerEnter(Collider other)
        {
            TriggerAction(other);;
        }
        protected override void TriggerAction(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            var rigidbodyPlayer = other.GetComponent<Rigidbody>();
            _direction = other.transform.position - transform.position;
            rigidbodyPlayer.AddForce(_direction * _force, ForceMode.Impulse);
        }
        internal override void CollisionAction(Collision collision) => Debug.LogWarning("No implementado {ImpulseBlock.SecondatyAction()}");

        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("Recycled ImpulseBlock");
    }
}