using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath.EntryPoints
{
    public class EntryPointGamePlay : MonoBehaviour, IEntryPoint
    {
        private DIContainer _container;

        [SerializeField] private CameraView _cameraView;
        [SerializeField] private CameraDataModel _cameraConfig;

        [SerializeField] private PauseMenuView _pauseMenuView;
        [SerializeField] private Transform _loadingScreen;

        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerModelData _playerData;
        [SerializeField] private Transform _parentPlayerPoolBullet;
        [SerializeField] private PoolDataService _playerPoolData;

        [SerializeField] private RoomView _startRoom;
        [SerializeField] private RoomTemplate _roomTemplate;
        [SerializeField] private RoomTemplate _roomBossTemplate;
        [SerializeField] private RoomTemplate _roomGoldTemplate;
        [SerializeField] private DungeounView _dungeounView;

        [SerializeField] private EnemyFlyView _testFlyEnemy;
        public void Initialization(DIContainer parentContainer)
        {
            _loadingScreen.gameObject.SetActive(true);
            _container = parentContainer;
            _container.RegisterSingleton(factory => new PoolService<BulletView>(_parentPlayerPoolBullet, _playerPoolData), "playerPool");
            _container.RegisterSingleton(factory => new CameraModel(_cameraConfig));
            RegisterModel(_container);
            RegisterController(_container);
            GenerateRooms(_container);
            Invoke(nameof(IsLoaded), 2f);
        }

        public void RegisterModel(DIContainer container)
        {
            var sceneService = container.Resolve<SceneService>();
            container.RegisterSingleton(factory => new PauseMenuModel(sceneService.LoadMainMenu));

            container.RegisterSingleton(factory => new PlayerModel(_playerData, container, 
                                                                   container.Resolve<PoolService<BulletView>>("playerPool")));
            container.Register(factory => new DoorModel(container.Resolve<CameraModel>(), container.Resolve<PlayerModel>()));
            
            container.Register(factory => new SpawnPointModel(_roomTemplate, factory));

            container.Register(factory => new BulletModel());

            container.Register(factory => new EnemyFlyModel(100, container.Resolve<PoolService<BulletView>>("playerPool")));

            container.RegisterSingleton(factory => new DungeounModel(_roomBossTemplate, _roomGoldTemplate));

        }

        private void RegisterController(DIContainer container)
        {
            var pauseMenuController = ExtentionService.SetupController<PauseMenuController, PauseMenuView>(_pauseMenuView);
            pauseMenuController.Bind(_pauseMenuView, container.Resolve<PauseMenuModel>());

            var playerController = ExtentionService.SetupController<PlayerControlller, PlayerView>(_playerView);
            playerController.Bind(_playerView, container.Resolve<PlayerModel>());

            var cameraController = ExtentionService.SetupController<CameraController, CameraView>(_cameraView);
            cameraController.Bind(_cameraView, container.Resolve<CameraModel>());

            var enemyFlyTestController = ExtentionService.SetupController<EnemyFlyController, EnemyFlyView>(_testFlyEnemy);
            enemyFlyTestController.Bind(_testFlyEnemy, container.Resolve<EnemyFlyModel>());
        }

        private void GenerateRooms(DIContainer container)
        {
            var roomController = ExtentionService.SetupController<RoomController, RoomView>(_startRoom);
            roomController.Bind(_startRoom, null);
            roomController.Initialization(container, _dungeounView.transform);

            var dungeounController = ExtentionService.SetupController<DungeounController, DungeounView>(_dungeounView);
            dungeounController.Bind(_dungeounView, container.Resolve<DungeounModel>());
            
        }

        private void IsLoaded()
        {
            _loadingScreen.gameObject.SetActive(false);
        }

    }
}