using UnityEngine;

namespace TowerOfDeath
{
    public class CameraView : MonoBehaviour, IView
    {
        private Vector3 _newPosition;
        [SerializeField] private float _smoothSpeed = 2f;

        public void Start()
        {
            _newPosition = transform.position;
        }
        public void Move(Vector2 direction)
        {
            _newPosition += new Vector3(direction.x, direction.y);
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _smoothSpeed);
        }
    }
}