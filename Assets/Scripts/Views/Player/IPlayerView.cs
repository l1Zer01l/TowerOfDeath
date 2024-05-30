using UnityEngine;

namespace TowerOfDeath
{
    public interface IPlayerView : IView
    {
        bool isActive { get; set; }
        float speed { get; set; }
        void Move(Vector3 direction);
    }
}
