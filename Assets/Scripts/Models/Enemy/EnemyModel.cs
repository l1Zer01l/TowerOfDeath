using System;
using TowerOfDeath.Services;
using UnityEngine;
using UnityEngine.UIElements;

namespace TowerOfDeath
{
    public abstract class EnemyModel : IEnemyModel
    {
        protected float _health;
        protected Vector2 _position;
        private PoolService<BulletView> _poolBulletService;
        public float health { get => _health; protected set { _health = value; healthChangedEvent?.Invoke(this, value); } }
        public Vector2 position { get => _position; protected set { _position = value; positionChangedEvent?.Invoke(this, value); } }
        public event Action<object, float> healthChangedEvent;
        public event Action<object, Vector2> positionChangedEvent;
        public event Action<object> enemyIsDeadEvent;
        public EnemyModel(Vector2 startPosition, float health, PoolService<BulletView> poolBulletService)
        {
            _position = startPosition;
            _health = health;
            _poolBulletService = poolBulletService;
            healthChangedEvent += CheckEnemyIsDead;
        }

        public void Binded()
        {
            healthChangedEvent?.Invoke(this, _health);
            positionChangedEvent?.Invoke(this, _position);
        }

        public void TakeDamage(BulletView bullet, float damage)
        {
            _poolBulletService.Remove(bullet);
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
