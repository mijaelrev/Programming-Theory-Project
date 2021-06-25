using UnityEngine;

namespace Code.UIManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GamePanel _game;
        [Header("Configuration")]
        [SerializeField] private float _timeTic = 30f;
        [SerializeField] private float _dificult = 0.1f;
        [SerializeField] private float _changeSpawnTime = 0;
        private float _value;


        private void Start()
        {
            _value = _timeTic;
        }
        private void Update()
        {
            TicForChangeGlobalValues();
        }

        private void TicForChangeGlobalValues()
        {
            _value -= Time.deltaTime;
            if (_timeTic < 0)
            {
                _value = _timeTic;
            }
        }

        internal void PlayerDeath() => PlayerDeath();
        internal void Configure(GameManager gameManager) => gameManager = this;
        internal void DifficultyIncrease(float reduceValue) => reduceValue -= _dificult;

    }
}