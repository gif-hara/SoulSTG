using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace SoulSTG.ActorControllers
{
    public class ActorSpawnDataHolder : MonoBehaviour
    {
        private readonly Dictionary<string, float> floatData = new();

        public float GetFloatData(string key)
        {
            Assert.IsTrue(floatData.ContainsKey(key), $"Key not found: {key}");
            return floatData.TryGetValue(key, out var value) ? value : 0f;
        }

        public void SetFloatData(string key, float value)
        {
            floatData[key] = value;
        }
    }
}
