using System.Collections.Generic;
using UnityEngine;
using Code.ElementsManager;

namespace Code.Optimization
{
    public class BlockFactory
    {
        private readonly BlockConfiguration _blockConfiguration;
        private Dictionary<int, ObjectPool> _pools;


        public BlockFactory(BlockConfiguration configuration)
        {
            _pools = new Dictionary<int, ObjectPool>();
            _blockConfiguration = configuration;
            var blocks = _blockConfiguration.Blocks;
            foreach (var block in blocks)
            {
                var objectPool = new ObjectPool(block);
                objectPool.Init(50);
                _pools.Add(block.ID, objectPool);
            }
        }

        public Block Create(int id, Vector3 position, Quaternion rotation)
        {
            var objectPool = _pools[id];
            return objectPool.Spawn<Block>(position, rotation);
        }
    }
}