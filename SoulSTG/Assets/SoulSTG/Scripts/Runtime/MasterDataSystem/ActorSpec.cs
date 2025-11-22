using System;
using UnityEngine;
using HK;
using System.Collections.Generic;
using SoulSTG.WeaponControllers;

namespace SoulSTG.MasterDataSystem
{
    [Serializable]
    public class ActorSpec
    {
        [field: SerializeField]
        public string Id { get; private set; }

        [field: SerializeField]
        public float HitPoint { get; private set; }

        [field: SerializeField]
        public List<Weapon> InitialWeaponPrefabs { get; private set; }

        [Serializable]
        public class DictionaryList : DictionaryList<string, ActorSpec>
        {
            public DictionaryList() : base(x => x.Id)
            {
            }
        }
    }
}
