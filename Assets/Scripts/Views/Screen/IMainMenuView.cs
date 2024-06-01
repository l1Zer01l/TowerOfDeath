using UnityEngine.UI;

namespace TowerOfDeath
{
    public interface IMainMenuView : IView
    {
        bool isOpenSettings { get; set; }
        Button startGameButton { get; }
        Button settingsButton { get; }
        Button exitGameButton { get; }
        Button exitSettingsButton { get; }
    }
}
