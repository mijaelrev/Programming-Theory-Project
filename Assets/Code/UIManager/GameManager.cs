using UnityEngine;
using System.Threading.Tasks;

namespace Code.UIManager
{

    public class GameManager : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float _timeTic = 30f;
        [SerializeField] private float _dificult = 0.1f;
        [SerializeField] private float _changeSpawnTime = 0;
        private float _value;
        private bool _initialized = false;
        public bool Initialized { get => _initialized; private set => _initialized = value; }

        private MainMenu _mainMenu;
        internal void Configure(MainMenu mainMenu) => _mainMenu = mainMenu;

        internal void DifficultyIncrease(float reduceValue) => reduceValue -= _dificult;
        internal async void GameStart(int delay)
        {
            await Task.Delay(delay);
            Initialized = true;
        }
        internal async void GameEnd(int delay)
        {
            await Task.Delay(delay);
            Initialized = false;
        }
    }
}