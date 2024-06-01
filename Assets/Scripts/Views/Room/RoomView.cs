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

        public void Initialization(List<RoomView> tempalate, ICameraController cameraController, IPlayerModel model)
        {
            foreach (var point in _spawnPointViews)
                point.Initialization(tempalate, cameraController, model);
            foreach (var door in _doorView)
                door.Initialllization(model, cameraController);   
        }
    }
}