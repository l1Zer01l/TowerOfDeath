using UnityEngine;

namespace TowerOfDeath
{
    public interface IRoomModel : IModel
    {
        void SpawnEnemy(Transform transform);
    }
}