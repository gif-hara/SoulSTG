using HK;
using R3;
using SoulSTG.MasterDataSystem;

namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class ActorStatus : IActorAbility
    {
        private Actor actor;

        private readonly ReactiveProperty<float> currentHitPoint;

        public ReadOnlyReactiveProperty<float> CurrentHitPoint => currentHitPoint;

        public ActorStatus(ActorSpec actorSpec)
        {
            currentHitPoint = new ReactiveProperty<float>(actorSpec.HitPoint);
        }

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }

        public void TakeDamage(float damage)
        {
            if (currentHitPoint.Value <= 0)
            {
                return;
            }

            currentHitPoint.Value -= damage;
            if (currentHitPoint.Value <= 0)
            {
                actor.Event.Router.Publish(new ActorEvent.OnDie());
            }
        }
    }
}
