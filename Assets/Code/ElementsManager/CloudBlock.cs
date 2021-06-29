using UnityEngine;

namespace Code.ElementsManager
{
    public class CloudBlock : Block
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private void Start() => Init();
        protected override void TriggerAction(Collider other) => Debug.Log("No Implementedo");
        private void OnCollisionEnter(Collision collision) => CollisionAction(collision);
        internal override void CollisionAction(Collision collision) 
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            if(_particleSystem != null)
            {
                Instantiate(_particleSystem, _myTransform.position, _particleSystem.transform.rotation);
            }
            Invoke(nameof(Recycle), _touchTimeRecycle);
            
        }
        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("Recycled CloudBlock");
    }
}