using UnityEngine;

namespace TowerOfDeath
{
    public interface ICameraDataModel 
    {
        Vector2 startPosition { get; }
        float smoothSpeed { get; }
    }
}
