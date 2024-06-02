using System.Collections.Generic;

namespace TowerOfDeath
{
    public interface IRoomTemplate 
    {
        List<RoomView> roomViews { get; }
    }
}
