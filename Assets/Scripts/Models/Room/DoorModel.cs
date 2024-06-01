using UnityEngine;

namespace TowerOfDeath
{
    public class DoorModel : IDoorModel
    {
        
        private Vector2 _directionCamera;
        private Vector2 _directionPlayer;

        private ICameraModel _cameraModel;
        private IPlayerModel _playerModel;

        public DoorModel(ICameraModel cameraModel, IPlayerModel playerModel)
        {
            _cameraModel = cameraModel;
            _playerModel = playerModel;
        }
        public void Binded()
        {
           
        }

        public void UseDoor(DoorType type)
        {
            switch (type)
            {
                case DoorType.Up:
                    _directionCamera = new Vector2(0, 11);
                    _directionPlayer = new Vector2(0, 4);
                    break;
                case DoorType.Down:
                    _directionCamera = new Vector2(0, -11);
                    _directionPlayer = new Vector2(0, -4);
                    break;
                case DoorType.Left:
                    _directionCamera = new Vector2(-20, 0);
                    _directionPlayer = new Vector2(-6, 0);
                    break;
                case DoorType.Right:
                    _directionCamera = new Vector2(20, 0);
                    _directionPlayer = new Vector2(6, 0);
                    break;
            }
            _cameraModel.MoveToPosition(_directionCamera);
            _playerModel.MoveToPosition(_directionPlayer);
        }
    }
}