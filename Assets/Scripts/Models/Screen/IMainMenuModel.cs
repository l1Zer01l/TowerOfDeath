
using System;

namespace TowerOfDeath
{
    public interface IMainMenuModel : IModel
    {
        event Action<object, bool> isOpenSettingsChangedEvent;

        bool isOpenSettings { get; }
        void StartGame();
        void Exit();
        void OpenSettings();
        void CloseSettings();
    }   
}
