using System;

namespace TowerOfDeath.DI
{
    public class DIEntrySingleton<T> : DIEntry<T>
    {
        public DIEntrySingleton(DIContainer container, Func<DIContainer, T> factory) : base(container, factory)
        {
        }

        public override T Resolve()
        {
            throw new System.NotImplementedException();
        }
    }
}