using UnityEngine;
using System.Threading.Tasks;

namespace Code.World
{
    public class AntiFallDisable : MonoBehaviour
    {
        private UIManager.GameManager gameManager;
        private AntiFallDisable _antifall;
        private void Start() => Init();
        private async void Update() => await Disabler();

        private async Task Disabler()
        {
            if (gameManager.Initialized)
            {
                await Task.Delay(20000);
                if(_antifall == null) return;
                Destroy(gameObject);
            }
        }
        private void Init()
        {
            _antifall = this;
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager.GameManager>();
        }
    }
}