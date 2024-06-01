using UnityEngine;

namespace TowerOfDeath
{
    public class DoorView : MonoBehaviour, IDoorView
    {
        [SerializeField] private DoorType _doorType;
        public DoorType doorType => _doorType;
    }

    public enum DoorType
    {
        None = 0,
        Up,
        Down,
        Left,
        Right
    }
}