using UnityEngine;

namespace TowerOfDeath
{
    [CreateAssetMenu(fileName = "PoolData", menuName = "TowerOfDeath/new PoolData")]
    public class PoolDataService : ScriptableObject, IPoolDataService
    {
        public int poolAmount => _poolAmount;

        public bool isAutoExpand => _isAutoExpand;

        public GameObject prefab => _prefab;

        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _poolAmount;
        [SerializeField] private bool _isAutoExpand;
    }
}