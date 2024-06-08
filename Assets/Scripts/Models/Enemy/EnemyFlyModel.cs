using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class EnemyFlyModel : EnemyModel
    {
        private IPlayerModel _player;
        private Vector2 _smoothVector;
        private float _speed;
        public EnemyFlyModel(float speed, Vector2 startPosition, float health, PoolService<BulletView> poolBulletService, IPlayerModel player) 
                            : base(startPosition, health, poolBulletService)
        {
            _player = player;
            _speed = speed;
            _smoothVector = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        }

        public void FollowPlayer()
        {
            var direction = _player.position + _smoothVector - position;
            direction.Normalize();
            position += direction * Time.deltaTime * _speed;
        }

        public void Dead()
        {
            if (Random.Range(0f, 1f) > 0.7f)
                _player.HealthUp(0.5f);
        }
    }
}
