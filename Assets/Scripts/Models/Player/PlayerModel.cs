using System;
using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerModel : IPlayerModel
    {
        private PoolService<BulletView> _poolBulletService;

        private float _health;
        private float _speed;
        private float _speedFire;
        private float _speedBullet;
        private float _damageBullet;
        private bool _isActive;
        private Vector2 _position;
        public float speedFire { get => _speedFire; private set { _speedFire = value; speedFireChangedEvent?.Invoke(this, value); } }
        public float health { get => _health; private set { _health = value; HealthChangedEvent?.Invoke(this, value); }  }
        public Vector2 position { get => _position; private set { _position = value; positionChangedEvent?.Invoke(this, value); } }

        public event Action<object, float> HealthChangedEvent;
        public event Action<object, float> speedFireChangedEvent;
        public event Action<object, Vector2> positionChangedEvent;

        public PlayerModel(IPlayerModelData data, PoolService<BulletView> poolBulletService)
        {
            _poolBulletService = poolBulletService;

            _position = data.startPosition;
            _speedFire = data.startSpeedFire;
            _health = data.startHealth;
            _speed = data.startSpeed;
            _speedBullet = data.startSpeedBullet;
            _damageBullet = data.startDamageBullet;

            _isActive = true;
        }

        public void HealthUp(float health)
        {
            if (health < 0)
                return;
            this.health += health;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
                return;
            health -= damage;
        }

        public void Binded()
        {
            HealthChangedEvent?.Invoke(this, _health);
            speedFireChangedEvent?.Invoke(this, _speed);
            positionChangedEvent?.Invoke(this, _position);
        }

        public void Fire(Vector3 diretion)
        {
            var bullet = _poolBulletService.CreateBullet();
            bullet.transform.position = new Vector3(_position.x, _position.y) + diretion * 0.5f;
            bullet.transform.localScale = Vector3.one * _damageBullet / 10;
            bullet.Fire(diretion, _speedBullet, _damageBullet);
        }

        public void Move(Vector2 direction)
        {
            if (!_isActive)
                return;
            direction.Normalize();
            position += direction * Time.deltaTime * _speed;
        }

        public void MoveToPosition(Vector2 direction)
        {
            position += direction;
        }
    }
}
