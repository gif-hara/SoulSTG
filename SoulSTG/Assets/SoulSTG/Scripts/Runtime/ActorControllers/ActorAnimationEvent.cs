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
            actor.GetAbility<Movement>().CanMove.Value = value == 1;
        }

        public void SetCanRotate(int value)
        {
            actor.GetAbility<Movement>().CanRotate.Value = value == 1;
        }

        public void SetRotateImmediateTargetRotation()
        {
            actor.GetAbility<Movement>().RotateImmediate(actor.GetAbility<Movement>().TargetRotation);
        }

        public void PlaySfx(string key)
        {
            TinyServiceLocator.Resolve<AudioManager>().PlaySfx(key);
        }
    }
}
