using System;
using UnityEngine;

namespace TowerOfDeath
{
    public class PauseMenuModel : IPauseMenuModel
    {
        public bool isOpenSettings 
        {
            get => _isOpenSettings; private set 
            { 
                _isOpenSettings = value;                                                             
                isOpenSettingsChangedEvent?.Invoke(this, _isOpenSettings); 
            } 
        }

        public bool isOpenPauseMenu
        {
            get => _isOpenPauseMenu; private set
            {
                _isOpenPauseMenu = value;
                isOpenPauseMenuChangedEvent?.Invoke(this, _isOpenPauseMenu);
            }
        }

        public event Action<object, bool> isOpenSettingsChangedEvent;
        public event Action<object, bool> isOpenPauseMenuChangedEvent;

        private bool _isOpenSettings;
        private bool _isOpenPauseMenu;
        private Action _loadMenu;
        public PauseMenuModel(Action loadMenu)
        {
            isOpenPauseMenuChangedEvent += CheckOpenPauseMenu;
            _isOpenSettings = false;
            _isOpenPauseMenu = false;
            _loadMenu = loadMenu;
        }

        public void Binded()
        {
            isOpenPauseMenuChangedEvent?.Invoke(this, _isOpenPauseMenu);
            isOpenSettingsChangedEvent?.Invoke(this, _isOpenSettings);
        }

        public void CloseSettings()
        {
            isOpenSettings = false;
        }

        public void ContinueGame()
        {
            isOpenPauseMenu = false;
        }

        public void Exit()
        {
            _loadMenu();
        }

        public void OpenSettings()
        {
            isOpenSettings = true;
        }

        public void OpenPauseMenu()
        {
            isOpenPauseMenu = true;
        }

        private void CheckOpenPauseMenu(object sender, bool isOpenPause)
        {
            if (isOpenPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
    }
}