using System;
using System.Collections.Generic;

namespace SimpleCaching
{
    public static class CacheInvalidator
    {
        private static readonly Dictionary<Type, string> CacheValues;

        static CacheInvalidator()
        {
            CacheValues = new Dictionary<Type, string>();
        }

        public static void MarkAsInvalid(Type type)
        {
            CacheValues[type] = GetANewCacheValue();
        }

        private static string GetANewCacheValue()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GetCacheValue(Type type)
        {
            if (CacheValues.ContainsKey(type) == false)
                CacheValues[type] = GetANewCacheValue();
            return CacheValues[type];
        }
    }
}