using UnityEngine;

namespace TowerOfDeath
{
    public interface IPoolDataService
    {
        int poolAmount { get; }
        bool isAutoExpand { get; }
        GameObject prefab { get; }
    }
}