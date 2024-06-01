using System;
using UnityEngine;

namespace TowerOfDeath
{
    public interface IPlayerModel : IModel
    {
        event Action<object, float> HealthChangedEvent;
        event Action<object, float> speedFireChangedEvent;
        event Action<object, Vector2> positionChangedEvent;
        Vector2 position { get; }
        float speedFire { get; }
        float health { get; }
        void TakeDamage(float damage);
        void HealthUp(float health);

        void Fire(Vector3 diretion);

        void Move(Vector2 direction);
        void MoveToPosition(Vector2 newPosition);
    }
}
