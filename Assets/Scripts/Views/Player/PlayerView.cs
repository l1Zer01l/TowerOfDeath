using UnityEngine;

namespace TowerOfDeath
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public bool isActive { get; set; }
        public float speed { get; set; }
        public void Move(Vector3 direction)
        {
            if (!isActive)
                return;

            transform.position += Vector3.Normalize(direction) * speed * Time.deltaTime;
        }
    }
}
