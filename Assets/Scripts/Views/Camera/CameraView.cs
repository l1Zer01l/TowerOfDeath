using UnityEngine;

namespace TowerOfDeath
{
    public class CameraView : MonoBehaviour, ICameraView
    {
        public Vector2 position { get => transform.position; set => transform.position = new Vector3(value.x, value.y, -10); }
        
    }
}