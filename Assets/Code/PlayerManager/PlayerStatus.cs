using UnityEngine;

namespace Code.PlayerManager
{
    public class PlayerStatus : MonoBehaviour, IKilleable
    {
        private string _myString;
        private readonly ElementsManager.Block _block;

        public PlayerStatus(ElementsManager.Block block) => _block = block;

        public void OnPlayerKill()
        {
            _block.PlayerKill();
        }
    }
}