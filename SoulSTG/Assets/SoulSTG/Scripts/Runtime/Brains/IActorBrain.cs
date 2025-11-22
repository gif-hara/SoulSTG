using System.Threading;

namespace SoulSTG.ActorControllers.Brains
{
    public interface IActorBrain
    {
        void Attach(Actor actor, CancellationToken cancellationToken);
    }
}
