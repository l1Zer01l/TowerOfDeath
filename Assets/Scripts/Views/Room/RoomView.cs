using System.Collections.Generic;
using UnityEngine;

namespace TowerOfDeath
{
    public class RoomView : MonoBehaviour, IRoomView
    {
        public List<SpawnRoomType> spawnRoomType => _spawnRoomType;
        public List<SpawnPointView> spawnPointViews => _spawnPointViews;
        public List<DoorView> doorViews => _doorViews;

        [SerializeField] private List<SpawnPointView> _spawnPointViews;
        [SerializeField] private List<DoorView> _doorViews;
        [SerializeField] private List<SpawnRoomType> _spawnRoomType;
        
    }
}