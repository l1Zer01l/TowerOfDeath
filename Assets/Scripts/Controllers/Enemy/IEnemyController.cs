
namespace TowerOfDeath
{
    internal interface IEnemyController : IController
    {
        void TakeDamage(BulletView bullet, float damage);
    }
}
