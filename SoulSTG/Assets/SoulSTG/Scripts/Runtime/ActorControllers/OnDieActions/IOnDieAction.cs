using System.Threading;
using Cysharp.Threading.Tasks;

namespace SoulSTG.ActorControllers.OnDieActions
{
    public interface IOnDieAction
    {
        UniTask InvokeAsync(Actor owner, CancellationToken cancellationToken);
    }
}
