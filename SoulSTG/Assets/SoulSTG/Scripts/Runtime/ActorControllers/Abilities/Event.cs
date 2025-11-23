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

        public readonly struct BeginAttack
        {
            public readonly string AttackId;

            public BeginAttack(string attackId)
            {
                AttackId = attackId;
            }
        }

        public readonly struct EndAttack
        {
            public readonly string AttackId;

            public EndAttack(string attackId)
            {
                AttackId = attackId;
            }
        }
    }
}
