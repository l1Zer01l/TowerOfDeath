using UnityEngine;

namespace TowerOfDeath
{
    public class DoorView : MonoBehaviour, IView
    {
        [SerializeField] private DoorType _doorType;
        private ICameraController _cameraController;
        private Vector2 _directionCamera;
        private Vector2 _directionPlayer;
        private IPlayerModel _playerModel;
        public void Initialllization(IPlayerModel playerModel, ICameraController cameraController)
        {
            _cameraController = cameraController;
            _playerModel = playerModel;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.GetComponent<PlayerView>();
            if (player)
            {
                switch (_doorType)
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
                _cameraController.Move(_directionCamera);
                _playerModel.MoveToPosition(_directionPlayer);
            }
        }
    }

    public enum DoorType
    {
        None = 0,
        Up,
        Down,
        Left,
        Right
    }
}