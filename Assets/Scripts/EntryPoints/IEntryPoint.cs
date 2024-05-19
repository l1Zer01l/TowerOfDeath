using TowerOfDeath.DI;

namespace TowerOfDeath.EntryPoints
{
    public interface IEntryPoint 
    {
        void Initialization(DIContainer parentContainer);
    }
}
