﻿using UnityEngine;

namespace Code.ElementsManager
{
    public class BrickBlock : Block
    {
        [SerializeField] protected ParticleSystem _particle;

        private void Start() => Init();
        private void OnTriggerEnter(Collider other) => TriggerAction(other);
        protected override void TriggerAction(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            Instantiate(_particle, _myTransform.position, _particle.transform.rotation);
            Invoke(nameof(Recycle), _touchTimeRecycle); 
        }

        internal override void CollisionAction(Collision collision) => Debug.Log("No implement");
        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal void TimeRecycleObject(float time) => Invoke(nameof(Recycle), time);
        internal override void Release() => Debug.Log("Recycled BrickBlock");
        
    }

}