using System;

namespace TowerOfDeath
{
    public interface IEnemyModel : IModel
    {
        event Action<object, float> healthChangedEvent;
        event Action<object> enemyIsDeadEvent;
        public float health { get; }
        void TakeDamage(BulletView bullet, float damage);
    }
}
