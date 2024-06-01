using UnityEngine;

namespace TowerOfDeath
{
    public interface ICameraController : IController
    {
        void Move(Vector2 direction);
    }
}
