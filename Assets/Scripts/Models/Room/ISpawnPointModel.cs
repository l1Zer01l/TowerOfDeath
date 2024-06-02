using System;
using UnityEngine;

namespace TowerOfDeath
{
    public interface ISpawnPointModel : IModel
    {
        event Action<object, bool> isSpawnedChangedEvent;
        bool isSpawned { get; }
        void SpawnRoom(SpawnRoomType roomType, Transform transform, Transform parent);
        void SpawnedCollition();
        
    }
}
