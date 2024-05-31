using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerOfDeath
{
    public class RoomView : MonoBehaviour, IView
    {
        private static int _countAddedEnemy = 0;
        [SerializeField] private List<SpawnRoomType> _spawnRoomType;
        public List<SpawnRoomType> spawnRoomType => _spawnRoomType;

        [SerializeField] private List<SpawnPointView> _spawnPointViews;
        [SerializeField] private List<DoorView> _doorView;

        private List<TestEnemy> _enemy;

        [System.Obsolete]
        public void Initialization(List<RoomView> tempalate, CameraView cameraView, PlayerModel model, Dictionary<int, TestEnemy> enemys)
        {
            foreach (var point in _spawnPointViews)
                point.Initialization(tempalate, cameraView, model, enemys);
            foreach (var door in _doorView)
                door.Initialllization(model, cameraView);

            LoadEnemy(enemys);
        }

        private void LoadEnemy(Dictionary<int, TestEnemy> enemys)
        {
            var rand = Random.RandomRange(0, 5);

            if (rand + _countAddedEnemy > enemys.Count())
                return;
            
            _enemy = enemys.Skip(_countAddedEnemy).Take(rand).Select(keyPair => keyPair.Value).ToList();
            foreach (var enemy in _enemy)
            {
                enemy.transform.position = transform.position + new Vector3(new System.Random().Next(-3, 3), new System.Random().Next(-3, 3));
                enemy.gameObject.SetActive(true);
            }
            _countAddedEnemy += rand;
        }

    }
}