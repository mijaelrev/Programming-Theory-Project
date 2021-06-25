using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Code.ElementsManager;

namespace Code.Optimization
{
    public class ObjectPool
    {
        private readonly Block _prefab;
        private readonly HashSet<Block> _instantiateObjects;
        private Queue<Block> _recycledObjects;

        public ObjectPool(Block prefab)
        {
            _prefab = prefab;
            _instantiateObjects = new HashSet<Block>();
        }

        public void Init(int numberOfInitialObjects)
        {
            _recycledObjects = new Queue<Block>(numberOfInitialObjects);

            for (var i = 0; i < numberOfInitialObjects; i++)
            {
                var instance = InstantiateNewInstance();
                instance.gameObject.SetActive(false);
                _recycledObjects.Enqueue(instance);
            }
        }

        private Block InstantiateNewInstance()
        {
            var instance = Object.Instantiate(_prefab);
            instance.Configure(this);
            return instance;
        }

        public T Spawn<T>(Vector3 position, Quaternion rotation)
        {
            var blockObject = GetInstance();
            _instantiateObjects.Add(blockObject);
            blockObject.gameObject.SetActive(true);
            blockObject.transform.SetPositionAndRotation(position, rotation);
            blockObject.ReInit();
            return blockObject.GetComponent<T>();
        }

        private Block GetInstance()
        {
            if (_recycledObjects.Count > 0)
            {
                return _recycledObjects.Dequeue();
            }

            Debug.LogWarning($"Not enough recycled objets for {_prefab.name} consider increase the initial number of objets");
            var instance = InstantiateNewInstance();
            return instance;
        }

        public void RecycleGameObject(Block blockObject)
        {
            var wasInstantiated = _instantiateObjects.Remove(blockObject);
            Assert.IsTrue(wasInstantiated, $"{blockObject.name} was not instantiate on {_prefab.name} pool");

            blockObject.gameObject.SetActive(false);
            blockObject.Release();
            _recycledObjects.Enqueue(blockObject);
        }
    }
}