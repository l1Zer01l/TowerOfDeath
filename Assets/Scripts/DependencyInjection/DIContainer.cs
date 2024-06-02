using System;
using System.Collections.Generic;

namespace TowerOfDeath.DI
{
    public class DIContainer
    {
        private readonly Dictionary<(string, Type), DIEntry> _factoryMaps;
        private readonly HashSet<(string, Type)> _cachedKey;
        private DIContainer _parentContainer;

        public DIContainer(DIContainer container = null)
        {
            _factoryMaps = new Dictionary<(string, Type), DIEntry>();
            _cachedKey = new HashSet<(string, Type)>();

            _parentContainer = container;
        }

        public void RegisterSingleton<T>(Func<DIContainer, T> factory)
        {
            RegisterSingleton<T>(("", typeof(T)), factory);
        }
        public void RegisterSingleton<T>(Func<DIContainer, T> factory, string key)
        {
            RegisterSingleton<T>((key, typeof(T)), factory);
        }
        public void Register<T>(Func<DIContainer, T> factory)
        {
            Register<T>(("", typeof(T)), factory);
        }

        public void Register<T>(Func<DIContainer, T> factory, string key)
        {
            Register<T>((key, typeof(T)), factory);
        }

        public T Resolve<T>(string tag = "")
        {
            var key = (tag, typeof(T));

            if (_cachedKey.Contains(key))
                return default(T);

            _cachedKey.Add(key);

            T result = FindFactory<T>(key);

            _cachedKey.Remove(key);
            return result;
        }

        private T FindFactory<T>((string, Type) key)
        {
            T result;
            if (!_factoryMaps.ContainsKey(key))
            {
                if (_parentContainer == null)
                    return default(T);
                result = _parentContainer.Resolve<T>(key.Item1);
            }
            else
            {
                result = _factoryMaps[key].Resolve<T>();
            }
            return result;
        }

        private void Register<T>((string, Type) key, Func<DIContainer, T> factory)
        {
            if (_factoryMaps.ContainsKey(key))
                return;

            var dIEntry = new DIEntryTransient<T>(this, factory);

            _factoryMaps[key] = dIEntry;
        }

        private void RegisterSingleton<T>((string, Type) key, Func<DIContainer, T> factory)
        {
            if (_factoryMaps.ContainsKey(key))
                return;

            var dIentrySingleton = new DIEntrySingleton<T>(this, factory);

            _factoryMaps[key] = dIentrySingleton;
        }
    }
}