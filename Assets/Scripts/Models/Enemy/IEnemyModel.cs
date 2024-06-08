using System;
using UnityEngine;

namespace TowerOfDeath
{
    public interface IEnemyModel : IModel
    {
        event Action<object, float> healthChangedEvent;
        event Action<object, Vector2> positionChangedEvent;
        event Action<object> enemyIsDeadEvent;
        public float health { get; }
        public Vector2 position { get; }
        void TakeDamage(BulletView bullet, float damage);
    }
}
