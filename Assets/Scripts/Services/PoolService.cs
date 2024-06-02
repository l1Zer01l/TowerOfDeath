using UnityEngine;

namespace TowerOfDeath.Services
{
    public class PoolService<T> where T : PoolObject

    {
        private Transform _parent;
        private PoolObjects<T> _poolBullet;

        public PoolService(Transform transform, IPoolDataService data)
        {
            _parent = transform;
            var prefab = data.prefab.GetComponent<T>();
            _poolBullet = new PoolObjects<T>(prefab, data.poolAmount, transform, data.isAutoExpand);
        }

        public T CreateBullet()
        {
            var bullet = _poolBullet.GetFreeObject();
            bullet.transform.parent = null;
            return bullet;
        }

        public void RemoveBullet(T bullet)
        {
            bullet.transform.parent = _parent;
            bullet.gameObject.SetActive(false);
        }

    }
}
