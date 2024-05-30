using UnityEngine;

namespace TowerOfDeath
{
    public class BulletView : PoolObject, IBulletView
    {
        private Rigidbody2D _rigidbody2D;
        [SerializeField] private BulletFX _bulletFX;
        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Fire(Vector3 direction, float force)
        {
            _rigidbody2D.AddForce(new Vector2(direction.x, direction.y) * force);
        }

        protected override void Initialization()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerController = collision.gameObject.GetComponent<PlayerControlller>();
            
            if (playerController)
            {
                var fx = GameObject.Instantiate(_bulletFX, transform);
                fx.transform.parent = null;
                playerController.TakeDamage(this, 10);
            }
        }
    }
}
