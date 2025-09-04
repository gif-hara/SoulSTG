using System;
using UnityEngine;

namespace SoulSTG.ActorControllers.FloatSelectors
{
    [Serializable]
    public sealed class Constant : IFloatSelector
    {
        [SerializeField]
        private float value;

        public float GetValue(IFloatSelector.Data data)
        {
            return value;
        }
    }
}
