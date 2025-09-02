using HK;
using SoulSTG.MasterDataSystem;
using UnityEngine;

namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class ActorStatus : IActorAbility
    {
        private Actor actor;

        private readonly ActorSpec actorSpec;

        private float currentHitPoint;

        public ActorStatus(ActorSpec actorSpec)
        {
            this.actorSpec = actorSpec;
            currentHitPoint = actorSpec.HitPoint;
        }

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }

        public void TakeDamage(float damage)
        {
            if (currentHitPoint <= 0)
            {
                return;
            }

            currentHitPoint -= damage;
            if (currentHitPoint <= 0)
            {
                actor.Event.Router.Publish(new ActorEvent.OnDie());
            }
        }
    }
}
