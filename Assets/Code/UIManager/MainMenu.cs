using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Code.UIManager
{
    public class MainMenu : MonoBehaviour
    {

        [SerializeField] private MenuMenu _menu;
        [SerializeField] private MainOption _options;
        [SerializeField] private GamePanel _game;
        [SerializeField] private EndGame _endGame;

        [SerializeField] private PlayerSaveData _playerData;
        
        private void Awake()
        {
            _playerData.Configure(this);

            _menu.Configure(this);
            _options.Configure(this);
            _game.Configure(this);
            _endGame.Configure(this);

            _options.gameObject.SetActive(false);
            _game.gameObject.SetActive(false);
            _endGame.gameObject.SetActive(false);
            _menu.gameObject.SetActive(true);

            _playerData.LoadDataPersistence();
        }
        private void Start()
        {
            _menu.ShowInfo();
        }

        internal void StartGame()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _menu.gameObject.SetActive(false);
            _options.gameObject.SetActive(false);
            _endGame.gameObject.SetActive(false);

            _game.gameObject.SetActive(true);
            _playerData.LoadDataPersistence();
        }

        internal void GoMainMenu()
        {
            _options.gameObject.SetActive(false);
            _game.gameObject.SetActive(false);
            _endGame.gameObject.SetActive(false);

            _menu.gameObject.SetActive(true);

        }

        internal void GameOptions()
        {
            _menu.gameObject.SetActive(false);
            _game.gameObject.SetActive(false);
            _endGame.gameObject.SetActive(false);

            _options.gameObject.SetActive(true);

        }

        internal void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            _menu.gameObject.SetActive(false);
            _options.gameObject.SetActive(false);
            _endGame.gameObject.SetActive(false);

            _game.gameObject.SetActive(true);
            _playerData.SaveDataPersistence();
        }

        internal void GameOver()
        {
            _menu.gameObject.SetActive(false);
            _game.gameObject.SetActive(false);
            _options.gameObject.SetActive(false);

            _endGame.gameObject.SetActive(true);
            _playerData.SaveDataPersistence();
            _endGame.ShowFinalInfo(_playerData.playerName, _playerData.maxScore);
            Cursor.lockState = CursorLockMode.None;
        }

        internal void QuitGame()
        {
            _playerData.SaveDataPersistence();
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit(); // Goodbye
#endif
        }

        //Otros//

        internal void ChangeName(string playerName)
        {
            _menu.ChangeCurrentName(playerName);
            _playerData.SaveDataPersistence();
        }

        internal void ChangeMaxScore(float maxScore) => _playerData.UpdateMaxScore(maxScore);
        internal void OverrideName(string name) => _playerData.playerName = name;
        internal void OverrideScore(float score) => _playerData.maxScore = score;
        internal string GetPlayerName() => _playerData.playerName;
        internal float GetPlayerMaxScore() => _playerData.maxScore;

    }
}