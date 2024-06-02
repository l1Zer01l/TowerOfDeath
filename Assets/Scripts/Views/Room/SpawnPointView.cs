using UnityEngine;

namespace TowerOfDeath
{
    public class SpawnPointView : MonoBehaviour, ISpawnPointView
    {
        
        [SerializeField] private bool _spawned;
        [SerializeField] private SpawnRoomType _spawnRoomType;
            
        public SpawnRoomType spawnRoomType => _spawnRoomType;
        public bool isSpawned { get => _spawned; set => _spawned = value; }
        
    }

    public enum SpawnRoomType
    {
        None = 0,
        RoomWithUpDoor,
        RoomWithDownDoor,
        RoomWithLeftDoor,
        RoomWithRightDoor
    }
}
