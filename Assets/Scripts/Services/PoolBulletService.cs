using UnityEngine;

namespace TowerOfDeath.Services
{
    public class PoolBulletService
    {
        private Transform _parent;
        private PoolObjects<BulletView> _poolBullet;

        public PoolBulletService(Transform transform, int poolAmount, bool autoExpand, BulletView prefab)
        {
            _parent = transform;
            _poolBullet = new PoolObjects<BulletView>(prefab, poolAmount, transform, autoExpand);
        }

        public BulletView CreateBullet()
        {
            var bullet = _poolBullet.GetFreeObject();
            bullet.transform.parent = null;
            return bullet;
        }

        public void RemoveBullet(BulletView bullet)
        {
            bullet.transform.parent = _parent;
            bullet.gameObject.SetActive(false);
        }

    }
}
