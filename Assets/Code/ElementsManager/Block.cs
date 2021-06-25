using UnityEngine;

namespace Code.ElementsManager
{
    public abstract class Block : MonoBehaviour
    {
        private Optimization.ObjectPool _objectPool;
        protected Spawner.Randomizer _randomizer;
        protected Transform _myTransform;

        [SerializeField] protected float _timeRecycle = 20f;
        [SerializeField] protected float _touchTimeRecycle = 0.15f;
        public int ID;

        protected virtual void Init()
        {
            if(_myTransform == null)
            {
                _myTransform = GetComponent<Transform>();
            }
            _randomizer = new Spawner.Randomizer();

        }

        protected abstract void TriggerAction(Collider other);
        internal abstract void CollisionAction(Collision collision);

        internal abstract void Release();
        internal abstract void ReInit();

        internal void Recycle() => _objectPool.RecycleGameObject(this);
        internal void Configure(Optimization.ObjectPool objectPool) => _objectPool = objectPool;

        internal virtual void PlayerKill()
        {
            var mediator = GameObject.FindGameObjectWithTag("Mediator");
            var mainMenu = mediator.GetComponent<UIManager.MainMenu>();
            Debug.Log("Player Is Death");
            mainMenu.GameOver();
        }

    }
}