using UnityEngine;

namespace TowerOfDeath
{
    public interface IEnemyView : IView
    {
        Vector2 position { get; set; }
    }
}
