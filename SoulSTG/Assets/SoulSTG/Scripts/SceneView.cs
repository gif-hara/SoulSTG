using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG
{
    public class SceneView : MonoBehaviour
    {
        [field: SerializeField]
        public LocatorHolder LocatorHolder { get; private set; }

        [field: SerializeField]
        public Animator Animator { get; private set; }

        [field: SerializeField]
        public ActorAnimationEvent ActorAnimationEvent { get; private set; }
    }
}
