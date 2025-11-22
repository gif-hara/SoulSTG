using System;
using Cysharp.Threading.Tasks;
using HK;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class ReleaseToPool : ISpawnAction
    {
        public UniTask InvokeAsync(ISpawnAction.Data data)
        {
            TinyServiceLocator.Resolve<GameObjectPool>().Release(data.SpawnedActor);
            return UniTask.CompletedTask;
        }
    }
}
