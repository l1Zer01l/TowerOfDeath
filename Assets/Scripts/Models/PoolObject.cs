using System.Collections.Generic;
using UnityEngine;

namespace TowerOfDeath
{
    public class PoolObjects<T> where T : PoolObject
    {
        public T prefab { get; }
        public Transform parent { get; }
        public bool autoExtend { get; set; }

        private List<T> m_pool;
        public PoolObjects(T prefab, int count, Transform parent) : this(prefab, count, parent, false) { }
        public PoolObjects(T prefab, int count, Transform parent, bool autoExtend = false)
        {
            this.prefab = prefab;
            this.autoExtend = autoExtend;
            this.parent = parent;
            CreatePool(count);
        }

        public T GetFreeObject()
        {
            if (HasFreeObject(out var prefab))
            {
                prefab.gameObject.SetActive(true);
                prefab.BaseInitialization();
                return prefab;
            }
            if (autoExtend)
            {
                var newPrefab = CreateObject();
                newPrefab.gameObject.SetActive(true);
                newPrefab.BaseInitialization();
                return newPrefab;
            }
            Debug.Log($"Don't have free pool object type: {typeof(T)}");
            return null;
        }


        public bool HasFreeObject(out T prefab)
        {
            prefab = m_pool.Find(i => !i.gameObject.activeInHierarchy);
            return prefab != null;
        }

        private void CreatePool(int count)
        {
            m_pool = new List<T>();
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isVisible = false)
        {
            var currentPrefab = Object.Instantiate(prefab, parent);
            currentPrefab.gameObject.SetActive(isVisible);
            m_pool.Add(currentPrefab);
            return currentPrefab;
        }
    }

    public abstract class PoolObject : MonoBehaviour
    {
        public void BaseInitialization()
        {
            Initialization();
        }
        protected abstract void Initialization();
    }
}