using UnityEngine;

namespace TowerOfDeath
{
    public interface ISpawnPointView : IView
    {
        SpawnRoomType spawnRoomType { get; }
        bool isSpawned { get; set; }
    }
}
