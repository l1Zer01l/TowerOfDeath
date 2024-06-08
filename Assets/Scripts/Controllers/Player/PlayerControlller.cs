using System.Collections.Generic;
using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerControlller : BaseController<IPlayerView, IPlayerModel>, IPlayerController
    {
        private Vector2 _directionMove = Vector2.zero;
        private Dictionary<string, Vector2> _lastDirectionMove = new Dictionary<string, Vector2>();
        private Vector2 _directionFire = Vector2.zero;

        private bool _isFire;
        private float _fireTimer;
        public void Update()
        {
            if (model is null || view is null)
                return;

            InputMove();
            InputFire();
        }
        public void TakeDamage(float damage)
        {
            model.TakeDamage(damage);
        }

        protected override void Bind()
        {
            model.HealthChangedEvent += OnHealthChanged;
            model.positionChangedEvent += OnPositionChanged;
        }
        protected override void UnBind()
        {
            model.HealthChangedEvent -= OnHealthChanged;
            model.positionChangedEvent -= OnPositionChanged;
        }
        private void InputMove()
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                _directionMove += Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                _directionMove += Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                _directionMove += Vector2.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _directionMove += Vector2.right;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                _directionMove -= Vector2.up;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                _directionMove -= Vector2.down;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _directionMove -= Vector2.left;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _directionMove -= Vector2.right;
            }

            view.SetAnimationMove(_directionMove);
            var directionResult = _directionMove;
            foreach (var collition in _lastDirectionMove.Keys)
                directionResult -= _lastDirectionMove[collition];
            model.Move(directionResult);           
        }

        private void InputFire()
        {          
            _fireTimer += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _directionFire += Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _directionFire += Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _directionFire += Vector2.left;        
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _directionFire += Vector2.right;               
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                _directionFire -= Vector2.up;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _directionFire -= Vector2.down;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _directionFire -= Vector2.left;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                _directionFire -= Vector2.right;
            }

            if (_directionFire.Equals(Vector2.zero))
                _isFire = false;
            else
                _isFire = true;

            if (_fireTimer <= model.speedFire)
                return;
            
            if (_isFire)
            {
                model.Fire(_directionFire);
                view.SetAnimationViewFire(_directionFire);
                _fireTimer = 0;
            }
        }

        private void OnPositionChanged(object sender, Vector2 newValue)
        {
            view.position = new Vector3(newValue.x, newValue.y);
        }

        private void OnHealthChanged(object sender, float newValue)
        {
            view.health = newValue;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_lastDirectionMove.ContainsKey(collision.gameObject.name))
            {
                _lastDirectionMove[collision.gameObject.name] = _directionMove;
                return;
            }

            _lastDirectionMove.Add(collision.gameObject.name, _directionMove);
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            _lastDirectionMove.Remove(collision.gameObject.name);
        }
    } 
}
