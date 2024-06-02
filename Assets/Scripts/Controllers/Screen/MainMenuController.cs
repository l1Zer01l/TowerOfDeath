
namespace TowerOfDeath
{
    public class MainMenuController : BaseController<IMainMenuView, IMainMenuModel>, IMainMenuController
    {
        protected override void Bind()
        {
            model.isOpenSettingsChangedEvent += OnIsOpenSettingsChanged;

            view.startGameButton.onClick.AddListener(StartGame);
            view.exitGameButton.onClick.AddListener(Exit);
            view.settingsButton.onClick.AddListener(OpenSettings);
            view.exitSettingsButton.onClick.AddListener(CloseSettings);
        }
        protected override void UnBind()
        {
            model.isOpenSettingsChangedEvent -= OnIsOpenSettingsChanged;
        }
        private void StartGame() 
        {
            model.StartGame();
        }
        private void Exit()
        {
            model.Exit();
        }
        private void OpenSettings()
        {
            model.OpenSettings();
        }
        private void CloseSettings()
        {
            model.CloseSettings();
        }

        private void OnIsOpenSettingsChanged(object sender, bool newValue)
        {
            view.isOpenSettings = newValue;
        }

        
    }
}
