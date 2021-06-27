using UnityEngine;
using UnityEngine.UI;

namespace Code.UIManager
{
    public class EndGame : MonoBehaviour
    {
        //[SerializeField] private Button _resumeGameButton;
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private Button _menuButton;

        [SerializeField] private TMPro.TMP_Text _name;
        [SerializeField] private TMPro.TMP_Text _score;
        private MainMenu _mainMenu;
        internal void Configure(MainMenu mainMenu) => _mainMenu = mainMenu;
        private void Awake()
        {

            _restartGameButton.onClick.AddListener(() => _mainMenu.RestartGame());
            _menuButton.onClick.AddListener(() => _mainMenu.GoMainMenuRestart());
        }

        internal void ShowFinalInfo(string name, float score)
        {
            _name.text = name;
            _score.text = score.ToString();
        }

    }
}