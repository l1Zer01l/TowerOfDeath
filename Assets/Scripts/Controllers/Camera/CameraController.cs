using UnityEngine;

namespace TowerOfDeath
{
    public class CameraController : BaseController<ICameraView, ICameraModel>, ICameraController
    {
        private Vector2 _newPosition = new Vector2();
        public void Move(Vector2 direction)
        {
            _newPosition += direction;
        }

        protected override void Bind()
        {
            model.positionChangedEvent += OnPositionChanged;
        }

        private void Update()
        {
            model.MoveToPosition(_newPosition);
        }

        private void OnPositionChanged(object sender, Vector2 newPosition)
        {
            view.position = newPosition;
        }
    }
}