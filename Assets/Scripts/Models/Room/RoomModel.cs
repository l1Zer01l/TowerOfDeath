using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class RoomModel : IRoomModel
    {
        private bool _isSpawnEnemy;
        private DIContainer _container;
        private EnemyFlyView _prefab;

        public RoomModel(DIContainer container, EnemyFlyView prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public void Binded()
        {

        }

        public void SpawnEnemy(Transform transform)
        {
            if(_isSpawnEnemy) 
                return;

            var rand = Random.Range(0, 5);
            for (int i = 0; i < rand; i++)
            {
                var position = transform.position + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
                var enemyFlyView = GameObject.Instantiate(_prefab, position, transform.rotation);
                var enemyFlyModel = new EnemyFlyModel(Random.Range(3f, 4f), position, Random.Range(80, 140),
                                                      _container.Resolve<PoolService<BulletView>>("playerPool"),
                                                      _container.Resolve<PlayerModel>());

                var enemyFlyController = ExtentionService.SetupController<EnemyFlyController, EnemyFlyView>(enemyFlyView);
                enemyFlyController.Bind(enemyFlyView, enemyFlyModel);
            }
            _isSpawnEnemy = true;
        }
    }
}