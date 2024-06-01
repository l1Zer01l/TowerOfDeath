using TowerOfDeath.DI;

namespace TowerOfDeath
{
    public interface IRoomController : IController
    {
        void Initialization(DIContainer container);
    }   
}
