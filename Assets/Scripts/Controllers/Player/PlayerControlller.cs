using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerControlller : BaseController<IPlayerView, IPlayerModel>
    {
        private Vector3 direction = Vector3.zero;

        public void Update()
        {
            InputMove();
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
                direction += Vector3.up;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                direction += Vector3.down;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                direction += Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                direction += Vector3.right;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                direction -= Vector3.up;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                direction -= Vector3.down;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                direction -= Vector3.left;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                direction -= Vector3.right;
            }

            view?.Move(direction);
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
