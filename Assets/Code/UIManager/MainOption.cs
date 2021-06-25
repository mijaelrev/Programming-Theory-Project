using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UIManager
{
    public class MainOption : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;
        [SerializeField] private TMP_Dropdown _qualities;
        private MainMenu _mainMenu;
        internal void Configure(MainMenu mainMenu) => _mainMenu = mainMenu;
        private void Awake()
        {
            _backToMenu.onClick.AddListener(() => _mainMenu.GoMainMenu());
            _qualities.onValueChanged.AddListener(delegate { ChangeQualities(); });
        }

        private void ChangeQualities()
        {

            Debug.Log("Value is changed");
        }
    }
}