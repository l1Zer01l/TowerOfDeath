using UnityEngine;

namespace TowerOfDeath
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "TowerOfDeath/New PlayerConfig")]
    public class PlayerModelData : ScriptableObject, IPlayerModelData
    {
        public Vector2 startPosition => _startPosition;

        public float startHealth => _startHealth;

        public float startSpeed => _startSpeed;

        public float startSpeedFire => _startSpeedFire;

        public float startSpeedBullet => _startSpeedBullet;
        public float startDamageBullet => _startDamageBullet;

        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private float _startHealth;
        [SerializeField] private float _startSpeedFire;
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _startSpeedBullet;
        [SerializeField] private float _startDamageBullet;
    }
}
