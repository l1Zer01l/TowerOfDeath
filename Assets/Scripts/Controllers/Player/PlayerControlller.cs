using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerControlller : BaseController<IPlayerView, IPlayerModel>, IPlayerController
    {
        private Vector3 _directionMove = Vector3.zero;
        private Vector3 _directionFire = Vector3.zero;

        private bool _isFire;
        private float _fireTimer;
        public void Update()
        {
            if (model is null || view is null)
                return;

            InputMove();
            InputFire();
        }
        public void TakeDamage(BulletView bullet, float damage)
        {
            model.TakeDamage(bullet, damage);
        }
        protected override void Bind()
        {
            model.isActiveChangedEvent += OnIsActiveChanged;
            model.speedChangedEvent += OnSpeedChanged;
        }

        private void InputMove()
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                _directionMove += Vector3.up;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                _directionMove += Vector3.down;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                _directionMove += Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _directionMove += Vector3.right;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                _directionMove -= Vector3.up;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _directionMove -= Vector3.down;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _directionMove -= Vector3.left;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _directionMove -= Vector3.right;
            }

            view.Move(_directionMove);
        }

        private void InputFire()
        {          
            _fireTimer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _directionFire = Vector3.up;
                _isFire = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _directionFire = Vector3.down;
                _isFire = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _directionFire = Vector3.left;
                _isFire = true;         
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _directionFire = Vector3.right;
                _isFire = true;                
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) ||
                Input.GetKeyUp(KeyCode.DownArrow) || 
                Input.GetKeyUp(KeyCode.LeftArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow))
                _isFire = false;

            if (_fireTimer <= model.speedFire)
                return;

            if (_isFire)
            {
                model.Fire(view.position, _directionFire);
                view.SetAnimationViewFire(_directionFire);
                _fireTimer = 0;
            }
        }

        private void OnIsActiveChanged(object sender, bool newValue)
        {
            view.isActive = newValue;
        }

        private void OnSpeedChanged(object sender, float newValue)
        {
            view.speed = newValue;
        }

        
    } 
}
