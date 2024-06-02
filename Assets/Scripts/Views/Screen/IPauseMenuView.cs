using UnityEngine.UI;

namespace TowerOfDeath
{
    public interface IPauseMenuView : IView
    {
        bool isOpenSettings { get; set; }
        bool isOpenPauseMenu { get; set; }
        Button continueGame { get; }
        Button settings { get; }
        Button closeSettings { get; }
        Button exit { get; }
        
    }
}
