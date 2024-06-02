using TowerOfDeath.DI;
using TowerOfDeath.Services;

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
        public void Initialization(DIContainer container)
        {
            foreach (var point in view.spawnPointViews)
            {
                var pointController = ExtentionService.SetupController<SpawnPointController, SpawnPointView>(point);
                pointController.Bind(point, container.Resolve<SpawnPointModel>());
            }
            foreach (var door in view.doorViews)
            {
                var doorController = ExtentionService.SetupController<DoorController, DoorView>(door);
                doorController.Bind(door, container.Resolve<DoorModel>());
            }
        }

        
    }
}
