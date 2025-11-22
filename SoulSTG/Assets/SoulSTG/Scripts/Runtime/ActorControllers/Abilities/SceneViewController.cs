using UnityEngine;

namespace SoulSTG.ActorControllers.Abilities
{
    public class SceneViewController : IActorAbility
    {
        [SerializeField]
        private SceneView sceneView;

        public void Activate(Actor actor)
        {
        }
    }
}
