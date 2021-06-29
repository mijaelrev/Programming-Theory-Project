using UnityEngine;
using Code.Optimization;
using Code.UIManager;

namespace Code.Spawner
{
    public class ObjectsSpawnManager : MonoBehaviour
    {
        private GameManager _gameManager;
        private Randomizer _randomizer = new Randomizer();
        private BlockFactory _factory;
        [SerializeField] private BlockConfiguration _blockConfig;
        [Header("Move Settigns")]
        [SerializeField] private int _upValue = 1;
        [SerializeField] private float _moveTime;

        private Transform _myTransform;
        private Vector3 _position = Vector3.zero;

        [SerializeField] private int _maxNumberInstances = 8;
        private void Awake() => _factory = new BlockFactory(_blockConfig);
        private void Start() => GameInit();
        private void Update() => TimeInstantiate();

        /// <summary>
        /// Tiempo de retraso de para instanciar
        /// </summary>
        private void TimeInstantiate()
        {
            if (_gameManager.Initialized)
            {
                _moveTime -= Time.deltaTime;
                if (_moveTime <= 0f)
                {
                    _position += Vector3.up * _upValue;
                    _moveTime = _upValue;
                    NewPoolObjectsInstancer();
                }
                _myTransform.position = _position;
            }

        }

        /// <summary>
        /// Crea objectos continuamente de forma aleatoria
        /// </summary>
        private void NewPoolObjectsInstancer()
        {
            
            for (int x = -_maxNumberInstances; x < _maxNumberInstances; x++)
            {

                for (int z = -_maxNumberInstances; z < _maxNumberInstances; z++)
                {
                    var newRandom = _randomizer.IntRandom(32);
                    if (newRandom < 1)
                    {
                        var newPositionZ = _myTransform.position.z + x;
                        var newPositionX = _myTransform.position.x + z;
                        var CurrentPositionSpawn = new Vector3(newPositionZ, transform.position.y, newPositionX);
                        var objectID = _randomizer.IntRandom(_blockConfig._blocks.Count);
                        _factory.Create(objectID, CurrentPositionSpawn, Quaternion.identity);

                    }
                    
                }

            }
        }

        /// <summary>
        /// Al iniciar el juego crea un cuadrado plano para evitar que el player caiga al vacio
        /// </summary>
        private void GameInit()
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            _myTransform = GetComponent<Transform>();
            _position += Vector3.up;

        }

    }


}