using HK;
using R3;
using SoulSTG.MasterDataSystem;

namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class Status : IActorAbility
    {
        private Actor actor;

        private readonly ReactiveProperty<float> currentHitPoint;

        public ReadOnlyReactiveProperty<float> CurrentHitPoint => currentHitPoint;

        public Status(ActorSpec actorSpec)
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
                actor.Event.Broker.Publish(new ActorEvent.OnDie());
            }
        }
    }
}
