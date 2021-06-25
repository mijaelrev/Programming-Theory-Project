using UnityEngine;
using Code.Optimization;

namespace Code.Spawner
{
    public class ObjectsSpawnManager : MonoBehaviour
    {
        private Randomizer _randomizer = new Randomizer();
        private BlockFactory _factory;
        [SerializeField] private BlockConfiguration _blockConfig;

        [Header("Move Settigns")]
        [SerializeField] private int _upValue = 1;
        [SerializeField] private float _moveTime;

        private Transform _myTransform;
        private Vector3 _position = Vector3.zero;

        [SerializeField] private int _maxNumberInstances = 8;
        private int _numberInstances;
        public static ObjectsSpawnManager Instance;
        private void Awake()
        {
            _factory = new BlockFactory(_blockConfig);
        }
        private void Start()
        {
            _myTransform = GetComponent<Transform>();

        }
        private void Update()
        {
            TimeInstantiate();

        }

        private void TimeInstantiate()
        {
            _moveTime -= Time.deltaTime;
            if (_moveTime <= 0f)
            {
                _position += Vector3.up * _upValue;
                _moveTime = _upValue;
                PoolObjectInstanciate();
            }
            _myTransform.position = _position;
        }

        private void PoolObjectInstanciate()
        {
            _numberInstances = _randomizer.IntRandom(_maxNumberInstances);
            for (int i = 0; i < _numberInstances; i++)
            {
                var randomNum = _randomizer.IntRandom(_maxNumberInstances);
                float xPosition = _myTransform.localPosition.x + _randomizer.IntRandom(randomNum, -randomNum);
                float zPosition = _myTransform.localPosition.z + _randomizer.IntRandom(randomNum, -randomNum);
                var currentPositionPlus = new Vector3(xPosition, _myTransform.position.y, zPosition);

                var objectId = _randomizer.IntRandom(_blockConfig._blocks.Count);

                _factory.Create(objectId, currentPositionPlus, Quaternion.identity);

            }
        }


    }


}