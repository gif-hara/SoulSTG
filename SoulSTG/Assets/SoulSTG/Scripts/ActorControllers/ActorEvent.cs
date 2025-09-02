using VitalRouter;

namespace SoulSTG.ActorControllers
{
    public class ActorEvent
    {
        public readonly Router Router = new();

        public readonly struct OnDie
        {
        }
    }
}
