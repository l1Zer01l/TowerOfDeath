using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private const string ANIMATION_X = "x";
        private const string ANIMATION_Y = "y";
        private const string ANIMATION_LAST_X = "lastX";
        private const string ANIMATION_LAST_Y = "lastY";

        private Animator _animator;
        private Vector3 _directionLast = Vector3.zero;

        public void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public bool isActive { get; set; }
        public float speed { get; set; }
        public void Move(Vector3 direction)
        {
            if (!isActive)
                return;

            direction = Vector3.Normalize(direction);

            if (direction.magnitude != 0)
                _directionLast = direction;

            //TODO: implementation animation player in FSM state machine 

            _animator.SetFloat(ANIMATION_X, direction.x);
            _animator.SetFloat(ANIMATION_Y, direction.y);
            _animator.SetFloat(ANIMATION_LAST_X, _directionLast.x);
            _animator.SetFloat(ANIMATION_LAST_Y, _directionLast.y);

            transform.position += direction * speed * Time.deltaTime;
            
        }
    }
}
