using UnityEngine;

namespace TowerOfDeath
{
    public class PauseMenuController : BaseController<IPauseMenuView, IPauseMenuModel>, IPauseMenuController
    {
        protected override void Bind()
        {
            model.isOpenPauseMenuChangedEvent += OnIsOpenPauseMenu;
            model.isOpenSettingsChangedEvent += OnIsOpenSettings;

            view.settings.onClick.AddListener(OpenSettings);
            view.closeSettings.onClick.AddListener(CloseSettings);
            view.exit.onClick.AddListener(ExitCurrentGame);
            view.continueGame.onClick.AddListener(ContinueGame);
        }

        protected override void UnBind()
        {
            model.isOpenPauseMenuChangedEvent -= OnIsOpenPauseMenu;
            model.isOpenSettingsChangedEvent -= OnIsOpenSettings;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (model.isOpenPauseMenu)
                    model.ContinueGame();
                else
                    model.OpenPauseMenu();
            }
        }

        private void OpenSettings() => model.OpenSettings();

        private void CloseSettings() => model.CloseSettings();

        private void ExitCurrentGame() => model.Exit();

        private void ContinueGame() => model.ContinueGame();

        private void OnIsOpenPauseMenu(object sender, bool newValue)
        {
            view.isOpenPauseMenu = newValue;
        }

        private void OnIsOpenSettings(object sender, bool newValue) 
        {
            view.isOpenSettings = newValue;
        }
    }
}