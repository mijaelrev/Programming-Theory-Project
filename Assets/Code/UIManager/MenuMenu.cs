using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Code.UIManager
{
    public class MenuMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_InputField _nameField;

        [SerializeField] private Button _startGame;
        [SerializeField] private Button _options;
        [SerializeField] private Button _exit;

        private MainMenu _mainMenu;
        internal void Configure(MainMenu mainMenu) => _mainMenu = mainMenu;
        private void Awake()
        {
            _startGame.onClick.AddListener(() => _mainMenu.StartGame());
            _options.onClick.AddListener(() => _mainMenu.GameOptions());
            _exit.onClick.AddListener(() => _mainMenu.QuitGame());

        }
        private void Start()
        {
            _nameField.text = _mainMenu.GetPlayerName();
            _nameField.onValueChanged.AddListener(delegate { _mainMenu.ChangeName(_nameField.text); });
            ShowInfo();
        }
        internal void ChangeCurrentName(string name)
        {
            _mainMenu.OverrideName(name);
            ShowInfo();
        }
        internal void ChangeCurrentScore(float score) => ChangeCurrentScore(score);

        internal void ShowInfo() 
            => _scoreText.text = $"Name: {_mainMenu.GetPlayerName()} Score: {_mainMenu.GetPlayerMaxScore()}";
    }
}