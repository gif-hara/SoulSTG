using HK;
using SoulSTG.ActorControllers.Abilities;
using UnityEngine;

namespace SoulSTG.ActorControllers
{
    public class ActorAnimationEvent : MonoBehaviour
    {
        private Actor actor;

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }

        public void SetCanMove(int value)
        {
            actor.GetAbility<ActorMovement>().CanMove.Value = value == 1;
        }

        public void SetCanRotate(int value)
        {
            actor.GetAbility<ActorMovement>().CanRotate.Value = value == 1;
        }

        public void SetRotateImmediateTargetRotation()
        {
            actor.GetAbility<ActorMovement>().RotateImmediate(actor.GetAbility<ActorMovement>().TargetRotation);
        }

        public void PlaySfx(string key)
        {
            TinyServiceLocator.Resolve<AudioManager>().PlaySfx(key);
        }
    }
}
