using UnityEngine;

namespace TowerOfDeath
{
    public class EnemyFlyController : BaseController<EnemyFlyView, EnemyFlyModel>, IEnemyFlyController
    {
        public void TakeDamage(BulletView bullet, float damage)
        {
            model.TakeDamage(bullet, damage);
        }

        protected override void Bind()
        {
            model.enemyIsDeadEvent += EnemyDead;
        }

        protected override void UnBind()
        {
            model.enemyIsDeadEvent -= EnemyDead;
        }

        private void EnemyDead(object sender)
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerController = collision.GetComponent<PlayerControlller>();
            if (playerController)
            {
                playerController.TakeDamage(0.5f);
            }
        }
    }
}
