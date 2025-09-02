using System;
using UnityEngine;

namespace SoulSTG.MasterDataSystem
{
    [Serializable]
    public class ActorSpec
    {
        [field: SerializeField]
        public float hitPoint { get; private set; }
    }
}
