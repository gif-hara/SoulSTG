using System;
using UnityEngine;

namespace SoulSTG.MasterDataSystem
{
    [Serializable]
    public class ActorSpec
    {
        [field: SerializeField]
        public float HitPoint { get; private set; }
    }
}
