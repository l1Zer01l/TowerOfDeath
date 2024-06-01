using UnityEngine;

namespace TowerOfDeath
{
    public interface ICameraView : IView
    {
        Vector2 position { get; set; }
    }   
}
