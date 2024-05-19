using TowerOfDeath.DI;
using UnityEngine;

namespace TowerOfDeath.EntryPoints
{
    public class EntryPointGamePlay : MonoBehaviour, IEntryPoint
    {
        private DIContainer _container;
        public void Initialization(DIContainer parentContainer)
        {
            _container = parentContainer;
        }
    }
}