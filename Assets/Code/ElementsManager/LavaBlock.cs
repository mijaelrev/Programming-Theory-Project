using UnityEngine;

namespace Code.ElementsManager
{
    public class LavaBlock : Block
    {
        [SerializeField] private float _timeKill = 1f;
        private float _currentTime;
        private bool _mustKill = false;

        private void Update() => KillThePlayer();

        private void KillThePlayer()
        {
            if (_mustKill)
            {
                _currentTime -= Time.deltaTime;

                if (_currentTime <= 0)
                {
                    PlayerKill();
                    _currentTime = 0;
                }
            }
            else
            {
                _currentTime = _timeKill;
            }
        }

        private void OnCollisionEnter(Collision collision) => CollisionAction(collision);
        private void OnCollisionExit(Collision collision) => CollisionAction(collision);
        protected override void TriggerAction(Collider other) { }
        internal override void CollisionAction(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            _mustKill = !_mustKill;
        }

        internal override void ReInit() => Invoke(nameof(Recycle), _timeRecycle);
        internal override void Release() => Debug.Log("LavaBlock Recycle");

    }
}