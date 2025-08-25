using SoulSTG.ActorControllers.Modifiers;
using TNRD;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    [CreateAssetMenu(fileName = "ActorModifiers", menuName = "SoulSTG/ActorModifiers")]
    public class ActorModifiers : ScriptableObject
    {
        [field: SerializeField]
        public SerializableInterface<IActorModifier>[] Modifiers { get; private set; }
    }
}
