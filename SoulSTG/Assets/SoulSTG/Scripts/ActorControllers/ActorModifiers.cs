using SoulSTG.ActorControllers.SpawnActions;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    [CreateAssetMenu(fileName = "ActorModifiers", menuName = "SoulSTG/ActorModifiers")]
    public class ActorSpawnActions : ScriptableObject
    {
        [field: SerializeField, ClassesOnly]
        public SerializableInterface<ISpawnAction>[] Actions { get; private set; }
    }
}
