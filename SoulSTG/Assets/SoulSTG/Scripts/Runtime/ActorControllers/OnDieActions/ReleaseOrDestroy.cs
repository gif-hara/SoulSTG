using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK;

namespace SoulSTG.ActorControllers.OnDieActions
{
    [Serializable]
    public sealed class ReleaseOrDestroy : IOnDieAction
    {
        public UniTask InvokeAsync(Actor owner, CancellationToken cancellationToken)
        {
            TinyServiceLocator.Resolve<GameObjectPool>().ReleaseOrDestroy(owner);
            return UniTask.CompletedTask;
        }
    }
}
