
namespace TowerOfDeath
{
    public interface IBulletView : IView
    {
        BulletFX bulletFX { get; }
        PoolObjects<BulletView> poolBullet { get; }
    }
}
