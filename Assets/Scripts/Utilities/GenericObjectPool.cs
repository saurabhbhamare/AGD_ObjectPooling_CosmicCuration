using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
        public T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.Item;
                }
            }
            return CreateItem();
        }
        public void  ReturnItem(T item)
        {
            PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
            pooledItem.isUsed = false;
        }
        protected virtual T CreateItem()
        {
            throw new NotImplementedException("not impl CreateItem in child class");
        }
        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }

}
