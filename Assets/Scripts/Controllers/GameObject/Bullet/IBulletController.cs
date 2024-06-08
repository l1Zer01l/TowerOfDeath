using UnityEngine;

namespace TowerOfDeath
{
    internal interface IBulletController
    {
        void Fire(Vector2 position, Vector3 direction, float force, float damage);
    }
}
