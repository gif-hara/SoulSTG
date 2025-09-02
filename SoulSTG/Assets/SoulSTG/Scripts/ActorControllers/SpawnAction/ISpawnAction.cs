using System.Threading;
using Cysharp.Threading.Tasks;

namespace SoulSTG.ActorControllers.SpawnActions
{
    public interface ISpawnAction
    {
        UniTask InvokeAsync(Actor owner, Actor spawnedActor, CancellationToken cancellationToken);
    }
}
