using System;
using UnityEngine;

namespace TowerOfDeath
{
    public interface IPlayerModel : IModel
    {
        event Action<object, float> HealthChangedEvent;
        event Action<object, bool> isActiveChangedEvent;
        event Action<object, float> speedChangedEvent;
        event Action<object, float> speedFireChangedEvent;
        float speedFire { get; }
        float speed { get; set; }
        float health { get; }
        bool isActive { get; set; }
        void TakeDamage(BulletView bullet, float damage);
        void HealthUp(float health);

        void Fire(Vector3 position, Vector3 diretion);
    }
}
