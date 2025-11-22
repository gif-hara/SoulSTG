using System;
using System.Collections.Generic;

namespace SoulSTG
{
    public sealed class FloatContainer
    {
        private readonly Dictionary<string, float> map = new();

        public void RegisterOrUpdate(string name, float value)
        {
            map[name] = value;
        }

        public float Resolve(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            if (map.TryGetValue(name, out var value))
                return value;

            throw new KeyNotFoundException($"No registration for ' {name}'");
        }

        public bool TryResolve(string name, out float value)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return map.TryGetValue(name, out value);
        }

        public void Clear()
        {
            map.Clear();
        }
    }
}