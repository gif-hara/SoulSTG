using System;
using UnityEngine;

namespace SoulSTG.ActorControllers.FloatSelectors
{
    [Serializable]
    public sealed class Constant : IFloatSelector
    {
        [SerializeField]
        private float value;

        public float GetValue(Actor actor)
        {
            return value;
        }
    }
}
