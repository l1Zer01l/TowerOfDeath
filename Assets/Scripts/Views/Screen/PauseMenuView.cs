using UnityEngine;
using UnityEngine.UI;

namespace TowerOfDeath
{
    public class PauseMenuView : MonoBehaviour, IPauseMenuView
    {
        public bool isOpenSettings 
        { 
            get => _settingsMenu.gameObject.activeSelf;
            set 
            {
                _settingsMenu.gameObject.SetActive(value);
                _menu.gameObject.SetActive(!value);
            } 
        }
        
        public bool isOpenPauseMenu { get => _pauseMenu.gameObject.activeSelf; set => _pauseMenu.gameObject.SetActive(value); }

        public Button continueGame => _continueGame;

        public Button settings => _settings;

        public Button closeSettings => _closeSettings;

        public Button exit => _exit;

        [SerializeField] private Button _continueGame;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _closeSettings;
        [SerializeField] private Button _exit;

        [SerializeField] private Transform _pauseMenu;
        [SerializeField] private Transform _menu;
        [SerializeField] private Transform _settingsMenu;
    }
}