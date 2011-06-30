using System.Linq;

namespace SimpleCaching
{
    public abstract class Cache
    {
        private string cacheValue;
        private static readonly object lockObject = new object();

        protected Cache()
        {
            cacheValue = CacheInvalidator.GetCacheValue(this.GetType());
        }

        public abstract void SetupTheCache();

        public void CheckTheCache()
        {
            if (TheCacheIsStillValid()) return;

            lock (lockObject)
                if (TheCacheIsInvalid())
                {
                    SetupTheCache();
                    cacheValue = GetTheCurrentCacheValue();
                }
        }

        private bool TheCacheIsStillValid()
        {
            return GetTheCurrentCacheValue() == cacheValue;
        }

        private bool TheCacheIsInvalid()
        {
            return TheCacheIsStillValid() == false;
        }

        private string GetTheCurrentCacheValue()
        {
            return CacheInvalidator.GetCacheValue(this.GetType().GetInterfaces().First());
        }
    }
}