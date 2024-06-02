using UnityEngine;

namespace TowerOfDeath
{
    public class SpawnPointController : BaseController<ISpawnPointView, ISpawnPointModel>, ISpawnPointController
    {
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
            Invoke(nameof(Spawn), 0.3f);
        }

        private void Spawn()
        {
            model.SpawnRoom(view.spawnRoomType, transform);
        }

        private void OnIsSpawnedChanged(object sender, bool newValue)
        {
            view.isSpawned = newValue;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spawnPointView = collision.GetComponent<SpawnPointView>();
            if (spawnPointView && spawnPointView.isSpawned)
            {
                Destroy(gameObject);
            }
        }
    }
}