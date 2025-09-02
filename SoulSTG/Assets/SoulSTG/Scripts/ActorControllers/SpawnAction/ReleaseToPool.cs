using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class ReleaseToPool : ISpawnAction
    {
        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, CancellationToken cancellationToken)
        {
            TinyServiceLocator.Resolve<GameObjectPool>().Release(spawnedActor);
            return UniTask.CompletedTask;
        }
    }
}
