using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath.EntryPoints
{
    public class EntryPointGamePlay : MonoBehaviour, IEntryPoint
    {
        private DIContainer _container;
        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private Transform _loadingScreen;

        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerModelData _playerData;
        [SerializeField] private Transform _parentPlayerPoolBullet;
        [SerializeField] private PoolDataService _playerPoolData;


        public void Initialization(DIContainer parentContainer)
        {
            _loadingScreen.gameObject.SetActive(true);
            _container = parentContainer;
            _container.RegisterSingleton(factory => new PoolService<BulletView>(_parentPlayerPoolBullet, _playerPoolData), "playerPool");
            RegisterModel(_container);
            RegisterController(_container);
            _loadingScreen.gameObject.SetActive(false);
        }

        public void RegisterModel(DIContainer container)
        {
            var sceneService = container.Resolve<SceneService>();
            container.RegisterSingleton(factory => new PauseMenuModel(sceneService.LoadMainMenu));

            container.RegisterSingleton(factory => new PlayerModel(_playerData, container.Resolve<PoolService<BulletView>>("playerPool")));
        }
        private void RegisterController(DIContainer container)
        {
            var pauseMenuController = ExtentionService.SetupController<PauseMenuController, PauseMenuView>(_pauseMenuView);
            pauseMenuController.Bind(_pauseMenuView, container.Resolve<PauseMenuModel>());

            var playerController = ExtentionService.SetupController<PlayerControlller, PlayerView>(_playerView);
            playerController.Bind(_playerView, container.Resolve<PlayerModel>());
        }
    }
}