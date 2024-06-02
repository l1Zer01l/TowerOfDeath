using UnityEngine;

namespace TowerOfDeath
{
    public interface IPlayerModelData
    {
        Vector2 startPosition { get; }
        float startHealth { get; }
        float startSpeed { get; }
        float startSpeedFire { get; }
    }
}