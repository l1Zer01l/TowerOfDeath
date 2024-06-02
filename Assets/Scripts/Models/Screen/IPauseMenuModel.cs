
using System;

namespace TowerOfDeath
{
    public interface IPauseMenuModel : IModel
    {
        event Action<object, bool> isOpenSettingsChangedEvent;
        event Action<object, bool> isOpenPauseMenuChangedEvent;
        bool isOpenSettings { get; }
        bool isOpenPauseMenu { get; }
        void ContinueGame();
        void OpenPauseMenu();
        void Exit();
        void OpenSettings();
        void CloseSettings();

    }
}
