using System;
using UnityEngine;

namespace TowerOfDeath
{
    public class MainMenuModel : IMainMenuModel
    {

        public event Action<object, bool> isOpenSettingsChangedEvent;

        public bool isOpenSettings { get => _isOpenSettings; private set { _isOpenSettings = value; isOpenSettingsChangedEvent?.Invoke(this, value); } }

        private Action _startGame;
        private bool _isOpenSettings;
        public MainMenuModel(Action startGame)
        {
            _startGame = startGame;
            _isOpenSettings = false;
        }

        public void Binded()
        {
            isOpenSettingsChangedEvent?.Invoke(this, _isOpenSettings);
        }

        public void CloseSettings()
        {
            isOpenSettings = false;
        }

        public void Exit()
        {

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }

        public void OpenSettings()
        {
            isOpenSettings = true;
        }

        public void StartGame()
        {
            _startGame();
        }
    }
}
