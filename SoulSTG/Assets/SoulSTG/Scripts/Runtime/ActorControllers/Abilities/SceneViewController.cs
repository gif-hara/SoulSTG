using UnityEngine;

namespace SoulSTG.ActorControllers.Abilities
{
    public class SceneViewController : IActorAbility
    {
        [field: SerializeField]
        public SceneView SceneView { get; private set; }

        public void Activate(Actor actor)
        {
        }
    }
}
