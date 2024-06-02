using UnityEngine;

namespace TowerOfDeath
{
    public class SpawnPointController : BaseController<ISpawnPointView, ISpawnPointModel>, ISpawnPointController
    {
        private Transform _parentSpawn;
        protected override void Bind()
        {
            model.isSpawnedChangedEvent += OnIsSpawnedChanged;
        }
        protected override void UnBind()
        {
            model.isSpawnedChangedEvent -= OnIsSpawnedChanged;
        }
        public void Start()
        {
            Invoke(nameof(Spawn), 0.1f);
        }
        public void SetParentSpawn(Transform parent)
        {
            _parentSpawn = parent;
        }
        private void Spawn()
        {
            model.SpawnRoom(view.spawnRoomType, transform, _parentSpawn);
        }

        private void OnIsSpawnedChanged(object sender, bool newValue)
        {
            view.isSpawned = newValue;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spawnPointView = collision.GetComponent<SpawnPointView>();
            if (spawnPointView)
            {
                if (!spawnPointView.isSpawned && !view.isSpawned)
                {
                    model.SpawnRoom(view.spawnRoomType | spawnPointView.spawnRoomType, transform, _parentSpawn);
                    Destroy(gameObject);
                }
                model.SpawnedCollition();
            }
        }
    }
}