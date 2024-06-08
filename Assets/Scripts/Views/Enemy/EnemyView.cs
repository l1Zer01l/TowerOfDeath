using UnityEngine;

namespace TowerOfDeath
{
    public abstract class EnemyView : MonoBehaviour, IEnemyView
    {
        public Vector2 position { get => transform.position; set => transform.position = value; }
    }
}
