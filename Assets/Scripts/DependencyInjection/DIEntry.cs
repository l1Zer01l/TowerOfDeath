using System;

namespace TowerOfDeath.DI
{
    public abstract class DIEntry
    {
        protected DIContainer _container { get; private set; }
        public DIEntry(DIContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return ((DIEntry<T>)this).Resolve();
        }
    }

    public abstract class DIEntry<T> : DIEntry
    {
        protected Func<DIContainer, T> _factory { get; private set; }

        public DIEntry(DIContainer container, Func<DIContainer, T> factory) : base(container)
        {
            _factory = factory;
        }
        public abstract T Resolve();

    }
}