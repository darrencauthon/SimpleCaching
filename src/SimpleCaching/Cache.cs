namespace SimpleCaching
{
    public abstract class Cache
    {
        private bool hasBeenCalled;

        public abstract void SetupTheCache();

        public void CheckTheCache()
        {
            if (hasBeenCalled) return;
            hasBeenCalled = true;
            SetupTheCache();
        }
    }
}