using System.Threading;
using Cysharp.Threading.Tasks;

namespace SoulSTG.ActorControllers.Actions
{
    public interface IAction
    {
        UniTask InvokeAsync(Actor actor, CancellationToken cancellationToken);
    }
}
