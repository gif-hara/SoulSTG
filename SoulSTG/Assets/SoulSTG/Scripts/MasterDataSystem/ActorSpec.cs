using System;
using UnityEngine;
using HK;

namespace SoulSTG.MasterDataSystem
{
    [Serializable]
    public class ActorSpec
    {
        [field: SerializeField]
        public string Id { get; private set; }

        [field: SerializeField]
        public float HitPoint { get; private set; }

        [Serializable]
        public class DictionaryList : DictionaryList<string, ActorSpec>
        {
            public DictionaryList() : base(x => x.Id)
            {
            }
        }
    }
}
