using System;

namespace TowerOfDeath
{
    public interface IPlayerModel : IModel
    {
        event Action<object, float> HealthChangedEvent;
        event Action<object, bool> isActiveChangedEvent;
        event Action<object, float> speedChangedEvent;
        float speed { get; set; }
        float health { get; set; }
        bool isActive { get; set; }
        void TakeDamage(float damage);
        void HealthUp(float health);
    }
}
