using System.Threading;
using Cysharp.Threading.Tasks;

namespace SoulSTG.ActorControllers.Modifiers
{
    public interface IActorModifier
    {
        UniTask InvokeAsync(Actor actor, Container container, CancellationToken cancellationToken);
    }
}
