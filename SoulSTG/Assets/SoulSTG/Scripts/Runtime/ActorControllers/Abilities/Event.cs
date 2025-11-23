using R3.Notifications;

namespace SoulSTG.ActorControllers.Abilities
{
    public class Event : IActorAbility
    {
        public MessageBroker Broker { get; } = new();

        public void Activate(Actor actor)
        {
        }

        public readonly struct OnDie
        {
        }

        public readonly struct Attack
        {
            public readonly string AttackId;

            public Attack(string attackId)
            {
                AttackId = attackId;
            }
        }
    }
}
