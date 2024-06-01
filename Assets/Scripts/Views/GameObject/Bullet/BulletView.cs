using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class BulletView : PoolObject, IBulletView
    {
        [SerializeField] private BulletFX _bulletFX;

        private Rigidbody2D _rigidbody2D;
        private PoolObjects<BulletView> _poolBullet;

        private float _damage = 10;


        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Fire(Vector2 direction, float force, float damage)
        {
            _rigidbody2D.AddForce(direction * force);
            _damage = damage;
        }
        protected override void Initialization<T>(PoolObjects<T> pool)
        {
            _poolBullet = pool as PoolObjects<BulletView>;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var enemyController = collision.gameObject.GetComponent<IEnemyController>();
            
            if (enemyController is not null)
            {
                CreateFX();
                enemyController.TakeDamage(this, _damage);
            }
            var wall = collision.gameObject.GetComponent<WallView>();
            var door = collision.gameObject.GetComponent<DoorView>();
            if (wall || door)
            {
                CreateFX();
                gameObject.SetActive(false);
                gameObject.transform.parent = _poolBullet.parent;
            }
        }

        private void CreateFX()
        {
            var fx = Instantiate(_bulletFX, transform.position + new Vector3(0, 0.5f, 0f), transform.rotation, transform.parent);
            fx.transform.parent = null;
        }
    }
}
