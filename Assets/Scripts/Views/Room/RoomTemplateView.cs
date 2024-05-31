using System.Collections.Generic;
using UnityEngine;

namespace TowerOfDeath
{
    public class RoomTemplateView : MonoBehaviour, IView
    {
        [SerializeField] private List<RoomView> _roomViews = new List<RoomView>();
        public List<RoomView> roomViews => _roomViews;
    }
}
