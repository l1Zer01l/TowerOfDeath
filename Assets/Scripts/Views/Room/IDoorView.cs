using UnityEngine;

namespace TowerOfDeath
{
    public interface IDoorView : IView
    {
        DoorType doorType { get; }
    }
}
