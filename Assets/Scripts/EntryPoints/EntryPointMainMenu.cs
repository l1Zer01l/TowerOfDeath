using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath.EntryPoints
{
    public class EntryPointMainMenu : MonoBehaviour, IEntryPoint
    {
        private DIContainer _container;

        [SerializeField] private MainMenuView _mainMenuView;

        public void Initialization(DIContainer parentContainer)
        {
            _container = parentContainer;
            RegisterModel(_container);
            RegisterController(_container);
        }

        private void RegisterModel(DIContainer container)
        {
            var sceneService = container.Resolve<SceneService>();
            container.RegisterSingleton(factory => new MainMenuModel(sceneService.LoadGamePlay));
        }

        private void RegisterController(DIContainer container)
        {
            var mainMenuController = ExtentionService.SetupController<MainMenuController, MainMenuView>(_mainMenuView);
            mainMenuController.Bind(_mainMenuView, container.Resolve<MainMenuModel>());
        }
    }
}