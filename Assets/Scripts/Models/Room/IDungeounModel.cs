
namespace TowerOfDeath
{
    public interface IDungeounModel : IModel
    {
        void AddRoom(RoomView room);

        void SpawnBossRoom();
        void SpawnGoldRoom();
    }
}
