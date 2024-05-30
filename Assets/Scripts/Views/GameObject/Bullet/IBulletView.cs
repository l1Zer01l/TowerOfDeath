using UnityEngine;

namespace TowerOfDeath
{
    public interface IBulletView : IView
    {
        void Fire(Vector3 direction, float force);
    }
}
