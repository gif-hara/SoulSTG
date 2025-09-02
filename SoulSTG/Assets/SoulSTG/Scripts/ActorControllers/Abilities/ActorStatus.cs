using SoulSTG.MasterDataSystem;

namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class ActorStatus : IActorAbility
    {
        private Actor actor;

        private readonly ActorSpec actorSpec;

        public ActorStatus(ActorSpec actorSpec)
        {
            this.actorSpec = actorSpec;
        }

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }
    }
}
