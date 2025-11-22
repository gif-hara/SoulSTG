namespace SoulSTG.ActorControllers.Abilities
{
    public sealed class ActorWeaponController : IActorAbility
    {
        private Actor actor;

        public void Activate(Actor actor)
        {
            this.actor = actor;
        }
    }
}
