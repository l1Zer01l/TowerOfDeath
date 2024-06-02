using UnityEngine;

namespace TowerOfDeath
{
    public class CameraController : BaseController<ICameraView, ICameraModel>, ICameraController
    {
        protected override void Bind()
        {
            model.positionChangedEvent += OnPositionChanged;
        }
        protected override void UnBind()
        {
            model.positionChangedEvent -= OnPositionChanged;
        }
        private void Update()
        {
            model?.Update();
        }

        private void OnPositionChanged(object sender, Vector2 newPosition)
        {
            view.position = newPosition;
        }

        
    }
}