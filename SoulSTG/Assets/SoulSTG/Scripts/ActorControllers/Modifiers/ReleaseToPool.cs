using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK;

namespace SoulSTG.ActorControllers.Modifiers
{
    [Serializable]
    public sealed class ReleaseToPool : IActorModifier
    {
        public UniTask InvokeAsync(Actor actor, Container container, CancellationToken cancellationToken)
        {
            TinyServiceLocator.Resolve<GameObjectPool>().Release(actor);
            return UniTask.CompletedTask;
        }
    }
}
