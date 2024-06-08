using TowerOfDeath.Services;
using UnityEngine;

namespace TowerOfDeath
{
    public class EnemyFlyModel : EnemyModel
    {
        public EnemyFlyModel(float health, PoolService<BulletView> poolBulletService) : base(health, poolBulletService)
        {

        }


    }
}
