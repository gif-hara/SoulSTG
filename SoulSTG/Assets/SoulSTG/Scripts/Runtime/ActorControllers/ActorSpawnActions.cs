using SoulSTG.ActorControllers.SpawnActions;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    [CreateAssetMenu(fileName = "ActorModifiers", menuName = "SoulSTG/ActorModifiers")]
    public class ActorSpawnActions : ScriptableObject
    {
#if UNITY_EDITOR
        [ClassesOnly]
#endif
        [field: SerializeField]
        public SerializableInterface<ISpawnAction>[] Actions { get; private set; }
    }
}
