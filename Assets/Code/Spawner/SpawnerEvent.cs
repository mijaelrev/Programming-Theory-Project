using UnityEngine;

namespace Code.Spawner
{
    public class SpawnerEvent : MonoBehaviour, IKilleable
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            OnPlayerKill();
        }
        public void OnPlayerKill()
        {
            var mediator = GameObject.FindGameObjectWithTag("Mediator");
            var mainMenu = mediator.GetComponent<UIManager.MainMenu>();
            Debug.Log("Player Is Death");
            mainMenu.GameOver();
        }
    }
}