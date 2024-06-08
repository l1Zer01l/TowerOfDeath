using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerOfDeath
{
    public class DungeounModel : IDungeounModel
    {
        private List<RoomView> _rooms;

        private bool _isSpawnedBoss;
        private bool _isSpawnedGold;

        private RoomTemplate _bossTemplate;
        private RoomTemplate _goldTemplate;

        public void AddRoom(RoomView room)
        {
            _rooms.Add(room);
        }

        public DungeounModel(RoomTemplate bossTemplate, RoomTemplate goldTemplate)
        {
            _rooms = new List<RoomView>();
            _isSpawnedBoss = false;
            _isSpawnedGold = false;
            _bossTemplate = bossTemplate;
            _goldTemplate = goldTemplate;
        }

        public void Binded()
        {

        }

        public void SpawnBossRoom()
        {
            if (_isSpawnedBoss)
                return;

            var room = _rooms.Where(room => room.isCanBeBoss).FirstOrDefault();
            var template = _bossTemplate.roomViews.Where(r => r.spawnRoomType.First().Equals(room.spawnRoomType.First())).FirstOrDefault();
            if (template is null)
                return;
            var roomBoss = GameObject.Instantiate(template, room.transform.position, room.transform.rotation, room.transform.parent);
            
            _rooms.Add(roomBoss);
            _isSpawnedBoss = true;

            _rooms.Remove(room);
            GameObject.Destroy(room);
        }

        public void SpawnGoldRoom()
        {
            if (_isSpawnedGold)
                return;

            var room = _rooms.Where(room => room.isCanBeGold).FirstOrDefault();
            var template = _goldTemplate.roomViews.Where(r => r.spawnRoomType.First().Equals(room.spawnRoomType.First())).FirstOrDefault();
            if (template is null)
                return;
            var roomGold = GameObject.Instantiate(template, room.transform.position, room.transform.rotation, room.transform.parent);
            _rooms.Add(roomGold);
            _isSpawnedGold = true;

            _rooms.Remove(room);
            GameObject.Destroy(room);
        }
    }
}