using System.Collections.Generic;
using UnityEngine;

namespace TowerOfDeath
{
    public interface IRoomView : IView
    {
        bool isCanBeBoss { get; }
        bool isCanBeGold { get; }
        Transform transform { get; }
        List<SpawnRoomType> spawnRoomType { get; }
        List<SpawnPointView> spawnPointViews { get; }
        List<DoorView> doorViews { get; }
    }   
}
