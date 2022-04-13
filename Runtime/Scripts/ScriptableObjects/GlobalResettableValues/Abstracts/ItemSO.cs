using UnityEngine;

namespace Nevelson.Utils
{
    public abstract class ItemSO<T> : ResettableSO
    {
        [SerializeField] protected T resetValue;
        [SerializeField] protected T item = default;

        public void Set(T item)
        {
            this.item = item;
        }

        public T Get()
        {
            return item;
        }

        protected override void ResetValue()
        {
            Debug.Log($"Resetting item: {name}");
            item = resetValue;
        }
    }
}