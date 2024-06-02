using UnityEngine;

namespace TowerOfDeath
{
    public interface ISpawnPointController : IController
    {
        void SetParentSpawn(Transform parent);
    }  
}
