using System;
using UnityEngine;

namespace TowerOfDeath
{
    public class CameraModel : ICameraModel
    {
        private Vector2 _position;
        private Vector2 _newPosition;
        private float _smoothSpeed;
        public Vector2 position { get => _position; private set { _position = value; positionChangedEvent?.Invoke(this, value); } }

        public event Action<object, Vector2> positionChangedEvent;
        public CameraModel(ICameraDataModel data)
        {
            _position = data.startPosition;
            _newPosition = data.startPosition;
            _smoothSpeed = data.smoothSpeed;
        }

        public void Binded()
        {
            positionChangedEvent?.Invoke(this, _position);
        }

        public void MoveToPosition(Vector2 newPosition)
        {
            _newPosition += newPosition;
        }

        public void Update()
        {
            position = Vector2.Lerp(position, _newPosition, Time.deltaTime * _smoothSpeed);
        }
    }
}
