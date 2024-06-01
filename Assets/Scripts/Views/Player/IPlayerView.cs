using UnityEngine;

namespace TowerOfDeath
{
    public interface IPlayerView : IView
    {
        Vector2 position { get; set; }
        void SetAnimationMove(Vector2 direction);
        void SetAnimationViewFire(Vector2 direction);
    }
}
