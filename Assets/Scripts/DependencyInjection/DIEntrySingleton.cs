using System;

namespace TowerOfDeath.DI
{
    public class DIEntrySingleton<T> : DIEntry<T>
    {
        private T _instance;
        public DIEntrySingleton(DIContainer container, Func<DIContainer, T> factory) : base(container, factory) { }
        public override T Resolve()
        {
            if (_instance == null)
            {
                _instance = _factory(_container);
            }
            return _instance;
        }
    }
}