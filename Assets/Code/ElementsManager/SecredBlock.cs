using System.Collections.Generic;
using UnityEngine;

namespace Code.ElementsManager
{
    public class SecredBlock : Block
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private GameObject _objectReplace;
        [SerializeField] private List<GameObject> _randomObjects;

        private void Start() => Init();

        private void OnTriggerEnter(Collider other)
        {
            TriggerAction(other);
            TimeRecycleObject(0.1f);
        }

        public void GenerateRandomObject()
        {
            int randomObject = _randomizer.IntRandom(_randomObjects.Count);
            Instantiate(_randomObjects[randomObject]);
            
        }
        protected override void TriggerAction(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            Instantiate(_particleSystem, _myTransform.position, _particleSystem.transform.rotation);
            if (_objectReplace == null) return;
            Instantiate(_objectReplace, _myTransform.position, Quaternion.identity);
        }

        internal override void CollisionAction(Collision collision) => Debug.LogWarning("Not Implemented");
        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);

        internal void TimeRecycleObject(float time) => Invoke(nameof(Recycle), time);
        internal override void Release() => Debug.Log("Recycled SecredBlock");

    }
}