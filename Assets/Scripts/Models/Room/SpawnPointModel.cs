using System;
using System.Collections.Generic;
using System.Linq;
using TowerOfDeath.DI;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class SpawnPointModel : ISpawnPointModel
    {
        private static int _maxRoom = 20;
        private static int _countRoom;

        private List<RoomView> _roomViews;
        private DIContainer _container;
        private bool _isSpawned;

        public SpawnPointModel(List<RoomView> roomViews, DIContainer container)
        {
            _roomViews = roomViews;
            _container = container;
            _isSpawned = false;
        }

        public bool isSpawned { get => _isSpawned; private set { _isSpawned = value; isSpawnedChangedEvent?.Invoke(this, value); } }

        public event Action<object, bool> isSpawnedChangedEvent;

        public void Binded()
        {
            isSpawnedChangedEvent?.Invoke(this, _isSpawned);
        }

        public void SpawnRoom(SpawnRoomType roomType, Transform transform)
        {
            if (_countRoom > _maxRoom)
                isSpawned = true;

            if (isSpawned)
                return;

            var template = new RoomView[0];
            switch (roomType)
            {
                case SpawnRoomType.RoomWithDownDoor:
                {
                    template = _roomViews.Where(room => room.spawnRoomType.Contains(SpawnRoomType.RoomWithDownDoor)).ToArray();
                    break;
                }
                case SpawnRoomType.RoomWithUpDoor:
                {
                    template = _roomViews.Where(room => room.spawnRoomType.Contains(SpawnRoomType.RoomWithUpDoor)).ToArray();
                    break;
                }
                case SpawnRoomType.RoomWithLeftDoor:
                {
                    template = _roomViews.Where(room => room.spawnRoomType.Contains(SpawnRoomType.RoomWithLeftDoor)).ToArray();
                    break;
                }
                case SpawnRoomType.RoomWithRightDoor:
                {
                    template = _roomViews.Where(room => room.spawnRoomType.Contains(SpawnRoomType.RoomWithRightDoor)).ToArray();
                    break;
                }
            }
            if (template.Length > 0)
                CreateRoom(template, transform);
        }

        private void CreateRoom(RoomView[] template, Transform transform)
        {
            var rand = UnityEngine.Random.Range(0, template.Length);
            var room = UnityEngine.Object.Instantiate(template[rand], transform.position, template[rand].transform.rotation);

            var roomController = ExtentionService.SetupController<RoomController, RoomView>(room);
            roomController.Bind(room, null);
            roomController.Initialization(_container);
            isSpawned = true;
            _countRoom++;
        }
    }
}
