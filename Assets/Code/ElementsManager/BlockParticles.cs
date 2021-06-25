using UnityEngine;

namespace Code.ElementsManager
{
    [RequireComponent(typeof(Rigidbody))]
    public class BlockParticles : MonoBehaviour
    {
        protected Spawner.Randomizer _randomValue = new Spawner.Randomizer();
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _minImpulse = 0, _maxImpulse = 10f;

        private Transform _myTransform;
        private bool mustAddForce;
        private void Start()
        {
            _myTransform = GetComponent<Transform>();
            mustAddForce = true;

            Destroy(gameObject, 10f);
        }

        private void FixedUpdate()
        {
            if (mustAddForce)
            {
                _rigidbody.AddForce(_randomValue.RandomVector(_myTransform.position, _minImpulse, _maxImpulse), ForceMode.Impulse);
                mustAddForce = false;
            }
        }


    }
}