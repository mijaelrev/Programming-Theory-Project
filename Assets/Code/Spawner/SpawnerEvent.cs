using UnityEngine;

namespace Code.Spawner
{
    public class SpawnerEvent : MonoBehaviour, IKilleable
    {
        private Collider _other;
        public void OnPlayerKill()
        {
            var mediator = GameObject.FindGameObjectWithTag("Mediator");
            var mainMenu = mediator.GetComponent<UIManager.MainMenu>();
            Debug.Log("Player Is Death");
            mainMenu.GameOver();
        }
    }
}