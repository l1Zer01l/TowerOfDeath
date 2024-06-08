using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class RoomController : BaseController<IRoomView, IRoomModel>, IRoomController
    {
        protected override void Bind()
        {
            
        }
        protected override void UnBind()
        {
            
        }
        public void Initialization(DIContainer container, Transform parentSpawn)
        {
            foreach (var point in view.spawnPointViews)
            {
                var pointController = ExtentionService.SetupController<SpawnPointController, SpawnPointView>(point);
                pointController.Bind(point, container.Resolve<SpawnPointModel>());
                pointController.SetParentSpawn(parentSpawn);
            }
            foreach (var door in view.doorViews)
            {
                var doorController = ExtentionService.SetupController<DoorController, DoorView>(door);
                doorController.Bind(door, container.Resolve<DoorModel>());
            }      
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerController = collision.GetComponent<PlayerControlller>();
            if (playerController)
            {
                model.SpawnEnemy(transform);
            }
        }
    }
}
