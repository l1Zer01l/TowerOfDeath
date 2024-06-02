using System.Collections.Generic;
using UnityEngine;

namespace TowerOfDeath
{
    [CreateAssetMenu(fileName = "RoomTemplate", menuName = "TowerOfDeath/new RoomTemplate")]
    public class RoomTemplate : ScriptableObject, IRoomTemplate
    {
        public List<RoomView> roomViews => _roomViews;

        [SerializeField] private List<RoomView> _roomViews;
    }
}
