using UnityEngine;
using System.Threading.Tasks;

namespace Code.World
{
    public class AntiFallDisable : MonoBehaviour
    {
        private UIManager.GameManager gameManager;

        private void Start() 
            => gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager.GameManager>();
        private async void Update()
        {
            await Disabler();
        }

        private async Task Disabler()
        {
            if (gameManager.Initialized)
            {
                await Task.Delay(20000);
                gameObject.SetActive(false);
            }
        }
    }
}