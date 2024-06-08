using System.Collections;
using UnityEngine;

namespace TowerOfDeath
{
    public class EnemyFlyController : BaseController<EnemyFlyView, EnemyFlyModel>, IEnemyFlyController
    {
        private Coroutine m_coroutineTakeDamage;

        private void Update()
        {
            if (model is null || view is null)
                return;
            model.FollowPlayer();
        }
        public void TakeDamage(BulletView bullet, float damage)
        {
            model.TakeDamage(bullet, damage);
        }

        protected override void Bind()
        {
            model.enemyIsDeadEvent += EnemyDead;
            model.positionChangedEvent += OnPositionChanged;
        }

        protected override void UnBind()
        {
            model.enemyIsDeadEvent -= EnemyDead;
            model.positionChangedEvent -= OnPositionChanged;
        }

        private void EnemyDead(object sender)
        {
            model.Dead();
            Destroy(gameObject);
        }
        private void OnPositionChanged(object sender, Vector2 newValue)
        {
            view.position = newValue;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerController = collision.GetComponent<PlayerControlller>();
            if (playerController)
            {
                playerController.TakeDamage(0.5f);
                m_coroutineTakeDamage = StartCoroutine(TakeDamagePeriod(playerController));
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var playerController = collision.GetComponent<PlayerControlller>();
            if (playerController)
            {
                StopCoroutine(m_coroutineTakeDamage);
            }
        }

        private IEnumerator TakeDamagePeriod(PlayerControlller playerController)
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                playerController.TakeDamage(0.5f);
            }
        }
    }
}
