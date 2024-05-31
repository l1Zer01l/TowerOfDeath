using UnityEngine;

namespace TowerOfDeath
{
    public interface IBulletView : IView
    {
        void Fire(Vector2 direction, float force, float damage);
    }
}
