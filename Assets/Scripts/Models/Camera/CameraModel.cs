using System;
using UnityEngine;

namespace TowerOfDeath
{
    public class CameraModel : ICameraModel
    {
        private Vector2 _position;
        private float _smoothSpeed;
        public Vector2 position { get => _position; private set { _position = value; positionChangedEvent?.Invoke(this, value); } }

        public event Action<object, Vector2> positionChangedEvent;
        public CameraModel(Vector2 position, float smoothSpeed)
        {
            _position = position;
            _smoothSpeed = smoothSpeed;
        }

        public void Binded()
        {
            positionChangedEvent?.Invoke(this, _position);
        }

        public void MoveToPosition(Vector2 newPosition)
        {
            position = Vector2.Lerp(position, newPosition, Time.deltaTime * _smoothSpeed);
        }
    }
}
