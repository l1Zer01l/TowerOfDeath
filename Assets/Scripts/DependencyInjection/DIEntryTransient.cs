using System;

namespace TowerOfDeath.DI
{
    public class DIEntryTransient<T> : DIEntry<T>
    {
        public DIEntryTransient(DIContainer container, Func<DIContainer, T> factory) : base(container, factory) { }

        public override T Resolve()
        {
            return _factory(_container);
        }
    }
}
