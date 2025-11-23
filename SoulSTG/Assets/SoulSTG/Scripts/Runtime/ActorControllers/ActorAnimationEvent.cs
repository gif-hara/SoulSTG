using HK;
using R3;
using R3.Triggers;
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

        public void SetRotateImmediateTargetRotation()
        {
            actor.GetAbility<Movement>().RotateImmediate(actor.GetAbility<Movement>().TargetRotation);
        }

        public void PlaySfx(string key)
        {
            TinyServiceLocator.Resolve<AudioManager>().PlaySfx(key);
        }

        public void SetMoveSpeedRate(float rate)
        {
            var movement = actor.GetAbility<Movement>();
            movement.MoveSpeedRate = rate;
            actor.GetAbility<SceneViewController>().SceneView.Animator.GetBehaviour<ObservableStateMachineTrigger>()
                .OnStateExitAsObservable()
                .Take(1)
                .Subscribe(movement, static (i, movement) =>
                {
                    movement.MoveSpeedRate = 1.0f;
                })
                .RegisterTo(actor.destroyCancellationToken);
        }

        public void SetRotateSpeedRate(float rate)
        {
            var movement = actor.GetAbility<Movement>();
            movement.RotateSpeedRate = rate;
            actor.GetAbility<SceneViewController>().SceneView.Animator.GetBehaviour<ObservableStateMachineTrigger>()
                .OnStateExitAsObservable()
                .Take(1)
                .Subscribe(movement, static (i, movement) =>
                {
                    movement.RotateSpeedRate = 1.0f;
                })
                .RegisterTo(actor.destroyCancellationToken);
        }

        public void PublishBeginAttackEvent(string attackId)
        {
            actor.GetAbility<Abilities.Event>().Broker.Publish(new Abilities.Event.BeginAttack(attackId));
        }

        public void PublishEndAttackEvent(string attackId)
        {
            actor.GetAbility<Abilities.Event>().Broker.Publish(new Abilities.Event.EndAttack(attackId));
        }
    }
}
