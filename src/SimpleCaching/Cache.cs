namespace SimpleCaching
{
    public abstract class Cache
    {
        private string cacheValue;
        private static readonly object LockObject = new object();

        public abstract void SetupTheCache();

        public virtual void CheckTheCache()
        {
            if (TheCacheIsStillValid()) return;

            lock (LockObject)
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
            return CacheInvalidator.GetCacheValue(this.GetType());
        }
    }
}