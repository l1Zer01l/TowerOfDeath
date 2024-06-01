using System.Collections.Generic;

namespace TowerOfDeath
{
    public interface IRoomView : IView
    {
        List<SpawnRoomType> spawnRoomType { get; }
        List<SpawnPointView> spawnPointViews { get; }
        List<DoorView> doorViews { get; }
    }   
}
