using UnityEngine;

namespace TowerOfDeath.Services
{
    public class PoolService<T> where T : PoolObject

    {
        private Transform _parent;
        private PoolObjects<T> _pool;

        public PoolService(Transform transform, IPoolDataService data)
        {
            _parent = transform;
            var prefab = data.prefab.GetComponent<T>();
            _pool = new PoolObjects<T>(prefab, data.poolAmount, transform, data.isAutoExpand);
        }

        public T Create()
        {
            var poolObject = _pool.GetFreeObject();
            poolObject.transform.parent = null;
            return poolObject;
        }

        public void Remove(T poolObject)
        {
            poolObject.transform.parent = _parent;
            poolObject.gameObject.SetActive(false);
        }

    }
}
