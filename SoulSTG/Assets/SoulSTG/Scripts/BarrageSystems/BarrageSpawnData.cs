using SoulSTG.BarrageSystems.Modifiers;
using SoulSTG.BarrageSystems.SpawnPointSelectors;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems
{
    [CreateAssetMenu(fileName = "BarrageSpawnData", menuName = "ScriptableObjects/BarrageSpawnData")]
    public class BarrageSpawnData : ScriptableObject
    {
        [field: SerializeField]
        public SerializableInterface<ISpawnPointSelector> SpawnPointSelector { get; private set; }

        [field: SerializeField]
        public SerializableInterface<IBarrageModifier>[] Modifiers { get; private set; }
    }
}
