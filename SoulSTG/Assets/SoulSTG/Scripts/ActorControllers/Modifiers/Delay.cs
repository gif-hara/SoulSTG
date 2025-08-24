using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SoulSTG.ActorControllers.Modifiers
{
    public sealed class Delay : IActorModifier
    {
        [field: SerializeField]
        private float seconds;

        public UniTask InvokeAsync(Actor actor, Container container, CancellationToken cancellationToken)
        {
            return UniTask.Delay(System.TimeSpan.FromSeconds(seconds), cancellationToken: cancellationToken);
        }
    }
}
