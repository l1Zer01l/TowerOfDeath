using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerOfDeath
{
    public class SpawnPointView : MonoBehaviour, IView
    {
        private static int _maxRoom = 20;
        private static int _countRoom;

        public bool spawned => _spawned;

        [SerializeField] private bool _spawned;
        [SerializeField] private SpawnRoomType _spawnRoomType;

        private List<RoomView> _roomViews;

        private CameraView _cameraView;
        private PlayerModel _playerModel;
        private Dictionary<int, TestEnemy> _enemys;
        public void Start()
        {
            if (_countRoom > _maxRoom)
                _spawned = true;

            Invoke(nameof(SpawnRoom), 0.3f);
        }
        public void Initialization(List<RoomView> template, CameraView cameraView, PlayerModel model, Dictionary<int, TestEnemy> enemys)
        {
            _roomViews = template;
            _cameraView = cameraView;
            _playerModel = model;
            _enemys = enemys;
        }
        private void SpawnRoom()
        {
            if (spawned)
                return;

            var template = new RoomView[0];
            switch (_spawnRoomType)
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
                CreateRoom(template);
        }

        private void CreateRoom(RoomView[] template)
        {
            var rand = Random.Range(0, template.Length);
            Instantiate(template[rand], transform.position, template[rand].transform.rotation).Initialization(_roomViews, _cameraView, _playerModel, _enemys);
            _spawned = true;
            _countRoom++;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spawnPointView = collision.GetComponent<SpawnPointView>();
            if (spawnPointView && spawnPointView.spawned)
            {

                Destroy(gameObject);
            }
        }

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
