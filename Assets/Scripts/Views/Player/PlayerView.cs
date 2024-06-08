using UnityEngine;
using UnityEngine.UI;

namespace TowerOfDeath
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private const string ANIMATION_X = "x";
        private const string ANIMATION_Y = "y";
        private const string ANIMATION_LAST_X = "lastX";
        private const string ANIMATION_LAST_Y = "lastY";

        private Animator _animator;
        private Vector2 _directionLast = Vector2.zero;
        [SerializeField] private Image m_healthBar;
        public void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public Vector2 position { get => transform.position; set => transform.position = value; }
        public float health { get => m_healthBar.fillAmount * 5; set => m_healthBar.fillAmount = value / 5; }

        public void SetAnimationMove(Vector2 direction)
        {
            if(direction.magnitude != 0)
                _directionLast = direction;

            _animator.SetFloat(ANIMATION_X, direction.x);
            _animator.SetFloat(ANIMATION_Y, direction.y);
            _animator.SetFloat(ANIMATION_LAST_X, _directionLast.x);
            _animator.SetFloat(ANIMATION_LAST_Y, _directionLast.y);
        }

        public void SetAnimationViewFire(Vector2 direction)
        {
            _directionLast = direction;
        }
    }
}
