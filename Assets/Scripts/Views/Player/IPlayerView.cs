using UnityEngine;

namespace TowerOfDeath
{
    public interface IPlayerView : IView
    {
        Vector3 position { get; }
        bool isActive { get; set; }
        float speed { get; set; }
        void Move(Vector3 direction);

        void SetAnimationViewFire(Vector3 direction);
    }
}
