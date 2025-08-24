using System;
using System.Collections.Generic;

namespace SoulSTG
{
    public sealed class Container
    {
        private readonly Dictionary<Type, Dictionary<string, object>> map = new();

        public void Register<T>(T obj, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var type = typeof(T);

            if (!map.TryGetValue(type, out var bucket))
            {
                bucket = new Dictionary<string, object>();
                map[type] = bucket;
            }

            if (bucket.ContainsKey(name))
                throw new InvalidOperationException($"Already registered: {type.FullName} '{name}'");

            bucket[name] = obj!;
        }

        public T Resolve<T>(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var type = typeof(T);

            if (map.TryGetValue(type, out var bucket) && bucket.TryGetValue(name, out var obj))
                return (T)obj;

            throw new KeyNotFoundException($"No registration for {type.FullName} '{name}'");
        }

        public bool TryResolve<T>(string name, out T value)
        {
            var type = typeof(T);
            if (map.TryGetValue(type, out var bucket) && bucket.TryGetValue(name, out var obj))
            {
                value = (T)obj;
                return true;
            }
            value = default!;
            return false;
        }
    }
}