using System;
using UnityEngine;

namespace TowerOfDeath
{
    public interface ICameraModel : IModel
    {
        event Action<object, Vector2> positionChangedEvent;

        Vector2 position { get; }
        void MoveToPosition(Vector2 direction);
        void Update();
    }
}