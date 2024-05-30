using System;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerModel : IPlayerModel
    {
        private PoolBulletService _poolBulletService;

        private float _health;
        private float _speed;
        private float _speedFire;
        private bool _isActive;
        
        public float speedFire { get => _speedFire; private set { _speedFire = value; speedFireChangedEvent?.Invoke(this, value); } }
        public float health { get => _health; private set { _health = value; HealthChangedEvent?.Invoke(this, value); }  }
        public bool isActive { get => _isActive; set { _isActive = value; isActiveChangedEvent?.Invoke(this, value); } }
        public float speed { get => _speed; set { _speed = value; speedChangedEvent?.Invoke(this, value); } }

        public event Action<object, float> HealthChangedEvent;
        public event Action<object, bool> isActiveChangedEvent;
        public event Action<object, float> speedChangedEvent;
        public event Action<object, float> speedFireChangedEvent;

        public PlayerModel(float health, float speed, float speedFire, PoolBulletService poolBulletService)
        {
            this.speedFire = speedFire;
            _poolBulletService = poolBulletService;
            this.health = health;
            this.speed = speed;
            isActive = true;
        }

        public void HealthUp(float health)
        {
            if (health < 0)
                return;
            this.health += health;
        }

        public void TakeDamage(BulletView bullet, float damage)
        {
            _poolBulletService.RemoveBullet(bullet);
            if (damage < 0)
                return;
            health -= damage;
        }

        public void Binded()
        {
            HealthChangedEvent?.Invoke(this, _health);
            isActiveChangedEvent?.Invoke(this, _isActive);
            speedChangedEvent?.Invoke(this, _speed);
        }

        public void Fire(Vector3 position, Vector3 diretion)
        {
            var bullet = _poolBulletService.CreateBullet();
            bullet.transform.position = position + diretion * 1f;
            bullet.Fire(diretion, 150);
        }
    }
}
