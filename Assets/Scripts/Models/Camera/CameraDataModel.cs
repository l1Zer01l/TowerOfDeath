using UnityEngine;

namespace TowerOfDeath
{
    [CreateAssetMenu(fileName ="CameraConfig", menuName = "TowerOfDeath/new CameraConfig")]
    public class CameraDataModel : ScriptableObject, ICameraDataModel
    {
        public Vector2 startPosition => _startPosition;

        public float smoothSpeed => _smoothSpeed;

        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private float _smoothSpeed;
    }
}