using UnityEngine;

namespace TowerOfDeath
{
    internal class BulletController : BaseController<BulletView, BulletModel>, IBulletController
    {
        private Rigidbody2D _rigidbody2D;
        private float _damage;
        public void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        protected override void Bind()
        {

        }

        protected override void UnBind()
        {

        }

        public void Fire(Vector2 position, Vector3 direction, float force, float damage)
        {
            _rigidbody2D.AddForce(direction * force);
            view.transform.position = new Vector3(position.x, position.y) + direction * 0.5f;
            view.transform.localScale = Vector3.one * damage / 10;
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var enemyController = collision.gameObject.GetComponent<IEnemyController>();

            if (enemyController is not null)
            {
                CreateFX();
                enemyController.TakeDamage(view, _damage);
            }
            var wall = collision.gameObject.GetComponent<WallView>();
            var door = collision.gameObject.GetComponent<DoorView>();
            if (wall || door)
            {
                CreateFX();
                gameObject.SetActive(false);
                gameObject.transform.parent = view.poolBullet.parent;
            }
        }

        private void CreateFX()
        {
            var fx = Instantiate(view.bulletFX, transform.position + new Vector3(0, 0.5f, 0f), transform.rotation, transform.parent);
            fx.transform.parent = null;
        }
        
    }
}
