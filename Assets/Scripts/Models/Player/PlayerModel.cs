using System;
using static UnityEngine.Rendering.DebugUI;

namespace TowerOfDeath
{
    public class PlayerModel : IPlayerModel
    {
        private float _health;
        private float _speed;

        private bool _isActive;
        
        public float health { get => _health; set { _health = value; HealthChangedEvent?.Invoke(this, value); }  }
        public bool isActive { get => _isActive; set { _isActive = value; isActiveChangedEvent?.Invoke(this, value); } }
        public float speed { get => _speed; set { _speed = value; speedChangedEvent?.Invoke(this, value); } }

        public event Action<object, float> HealthChangedEvent;
        public event Action<object, bool> isActiveChangedEvent;
        public event Action<object, float> speedChangedEvent;

        public PlayerModel(float health, float speed)
        {
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

        public void TakeDamage(float damage)
        {
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
    }
}
