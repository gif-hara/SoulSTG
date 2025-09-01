using SoulSTG.ActorControllers.Modifiers;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    [CreateAssetMenu(fileName = "ActorModifiers", menuName = "SoulSTG/ActorModifiers")]
    public class ActorModifiers : ScriptableObject
    {
        [field: SerializeField, ClassesOnly]
        public SerializableInterface<IActorModifier>[] Modifiers { get; private set; }
    }
}
