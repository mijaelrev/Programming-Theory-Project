using UnityEngine;
using TMPro;

namespace Code.UIManager
{
    public class GamePanel : MonoBehaviour
    {
        [Header("Time")]
        [SerializeField] private TextMeshProUGUI _time;
        private float _seconds;
        private int _minutes;
        private float _currentTime; //CurrentTime, that is private for security, for Get use TimeNow
        public float TimeNow => _currentTime; 
        [SerializeField] private string _newFormat;
        private MainMenu _mainMenu;

        internal void Configure(MainMenu mainMenu) => _mainMenu = mainMenu;

        private void Update()
        {
            if (_mainMenu.HasStart())
            {
                Chronometer();
            }
            _mainMenu.ChangeMaxScore(_currentTime);
        }

        private void Chronometer()
        {
            _currentTime += Time.deltaTime;
            _minutes = (int)_currentTime / 60;
            _seconds = _currentTime % 60;
            _time.text = System.String.Format(" Time: {0:00}:{1:00.00}", _minutes, _seconds);

        }
        internal void CurrentTimeReinit() => _currentTime = 0;
    }
}