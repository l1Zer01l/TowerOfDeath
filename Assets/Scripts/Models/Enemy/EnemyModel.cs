using System;
using TowerOfDeath.Services;

namespace TowerOfDeath
{
    public abstract class EnemyModel : IEnemyModel
    {
        protected float _health;

        private PoolService<BulletView> _poolBulletService;
        public float health { get => _health; protected set { _health = value; healthChangedEvent?.Invoke(this, value); } }

        public event Action<object, float> healthChangedEvent;
        public event Action<object> enemyIsDeadEvent;
        public EnemyModel(float health, PoolService<BulletView> poolBulletService)
        {
            _health = health;
            _poolBulletService = poolBulletService;
            healthChangedEvent += CheckEnemyIsDead;
        }

        public void Binded()
        {
            healthChangedEvent?.Invoke(this, _health);
        }

        public void TakeDamage(BulletView bullet, float damage)
        {
            _poolBulletService.RemoveBullet(bullet);
            if (damage < 0)
                return;
            health -= damage;
        }

        private void CheckEnemyIsDead(object sender, float health)
        {
            if (health < 0)
                enemyIsDeadEvent?.Invoke(this);
        }
    }
}
