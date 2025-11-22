using System.Collections.Generic;
using UnityEngine;

namespace SoulSTG.MasterDataSystem
{
    [CreateAssetMenu(fileName = "MasterData", menuName = "SoulSTG/MasterData")]
    public class MasterData : ScriptableObject
    {
        [field: SerializeField]
        public PlayerSpec PlayerSpec { get; private set; }

        [field: SerializeField]
        public ActorSpec.DictionaryList ActorSpecs { get; private set; }
    }
}
