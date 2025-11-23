using R3.Notifications;

namespace SoulSTG.ActorControllers
{
    public class ActorEvent
    {
        public MessageBroker Broker { get; } = new();

        public readonly struct OnDie
        {
        }
    }
}
