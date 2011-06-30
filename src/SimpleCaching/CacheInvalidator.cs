using System;
using System.Collections.Generic;

namespace SimpleCaching
{
    public static class CacheInvalidator
    {
        private static readonly Dictionary<Type, string> dictionary;

        static CacheInvalidator()
        {
            dictionary = new Dictionary<Type, string>();
        }

        public static void MarkAsInvalid(Type type)
        {
            dictionary[type] = Guid.NewGuid().ToString();
        }

        public static string GetCacheValue(Type type)
        {
            if (dictionary.ContainsKey(type) == false)
                dictionary[type] = Guid.NewGuid().ToString();
            return dictionary[type];
        }
    }
}