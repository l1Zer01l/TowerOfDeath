using UnityEngine;

namespace TowerOfDeath
{
    public class DoorController : BaseController<IDoorView, IDoorModel>, IDoorController
    {
        protected override void Bind()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var player = collision.GetComponent<PlayerView>();
            if (player)
            {
                model.UseDoor(view.doorType);
            }
        }

    }
}
