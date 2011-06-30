using System;
using System.Linq;

namespace SimpleCaching
{
    public abstract class Cache
    {
        private string cacheValue;

        protected Cache()
        {
            cacheValue = CacheInvalidator.GetCacheValue(this.GetType());
        }

        public abstract void SetupTheCache();

        public void CheckTheCache()
        {
            var currentCacheValue = CacheInvalidator.GetCacheValue(this.GetType().GetInterfaces().First());
            if (currentCacheValue == cacheValue) return;
            SetupTheCache();
            cacheValue = currentCacheValue;
        }
    }
}