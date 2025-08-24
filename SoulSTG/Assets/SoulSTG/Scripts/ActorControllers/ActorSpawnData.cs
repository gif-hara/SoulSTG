using SoulSTG.ActorControllers.Modifiers;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    [CreateAssetMenu(fileName = "ActorSpawnData", menuName = "SoulSTG/ActorSpawnData")]
    public class ActorSpawnData : ScriptableObject
    {
        [field: SerializeField]
        public Actor ActorPrefab { get; private set; }

        [field: SerializeField]
        public SerializableInterface<IActorModifier>[] Modifiers { get; private set; }
    }
}
