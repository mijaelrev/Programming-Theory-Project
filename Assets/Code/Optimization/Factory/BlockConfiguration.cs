using System.Collections.Generic;
using UnityEngine;
using Code.ElementsManager;

namespace Code.Optimization
{
    [CreateAssetMenu(fileName = "NewBlock", menuName = "Blocks")]
    public class BlockConfiguration : ScriptableObject
    {
        public List<Block> _blocks;
        private Dictionary<int, Block> _blocksDictionary;

        public List<Block> Blocks => _blocks;
        private void Awake()
        {
            _blocksDictionary = new Dictionary<int, Block>();
            foreach (var block in _blocks)
            {
                _blocksDictionary.Add(block.ID, block);
            }
        }
        public Block GetBlockPrefabID(int id)
        {
            if (!_blocksDictionary.TryGetValue(id,out var powerUp))
            {
                throw new System.Exception($"Block con el ID {id} no exite");
            }
            return powerUp;
        }
    }
}