using System.Collections.Generic;
using UnityEngine;

namespace Nevelson.Utils
{
    public abstract class CollectionSO<T> : ResettableSO
    {
        [SerializeField] protected List<T> resetValue = new List<T>();
        [SerializeField] protected List<T> items = new List<T>();
        public List<T> Get()
        {
            return items;
        }

        public void Set(List<T> items)
        {
            this.items = items;
        }

        public void Add(T genericItem)
        {
            if (!items.Contains(genericItem))
            {
                items.Add(genericItem);
            }
        }

        public void Remove(T genericItem)
        {
            if (items.Contains(genericItem))
            {
                items.Remove(genericItem);
            }
        }

        protected override void ResetValue()
        {
            Debug.Log($"Resetting items in list: {name}");
            items = resetValue;
        }
    }
}