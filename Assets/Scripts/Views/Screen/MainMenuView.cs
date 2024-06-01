using UnityEngine;
using UnityEngine.UI;

namespace TowerOfDeath
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        public Button startGameButton => _startGameButton;

        public Button settingsButton => _settingsButton;

        public Button exitGameButton => _exitGameButton;
        
        public Button exitSettingsButton => _exitSettingsButton;

        public bool isOpenSettings { get => settingCanvas.gameObject.activeSelf; set { mainMenuCanvas.gameObject.SetActive(!value);
                                                                                       settingCanvas.gameObject.SetActive(value); } }

        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitGameButton;
        [SerializeField] private Button _exitSettingsButton;
        [SerializeField] private Transform mainMenuCanvas;
        [SerializeField] private Transform settingCanvas;
    }
}
