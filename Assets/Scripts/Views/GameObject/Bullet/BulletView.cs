using UnityEngine;

namespace TowerOfDeath
{
    public class BulletView : PoolObject, IBulletView
    {
        [SerializeField] private BulletFX _bulletFX;

        
        private PoolObjects<BulletView> _poolBullet;

        public BulletFX bulletFX => _bulletFX;

        public PoolObjects<BulletView> poolBullet => _poolBullet;

        protected override void Initialization<T>(PoolObjects<T> pool)
        {
            _poolBullet = pool as PoolObjects<BulletView>;
        }
        
        
    }
}
