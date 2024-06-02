using System.Collections;
using TowerOfDeath.DI;
using UnityEngine;

namespace TowerOfDeath
{
    public interface IRoomController : IController
    {
        void Initialization(DIContainer container, Transform parentSpawn);
    }   
}
