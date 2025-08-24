using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SoulSTG.ActorControllers.Modifiers
{
    [Serializable]
    public sealed class Delay : IActorModifier
    {
        [field: SerializeField]
        private float seconds;

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, Container container, CancellationToken cancellationToken)
        {
            return UniTask.Delay(TimeSpan.FromSeconds(seconds), cancellationToken: cancellationToken);
        }
    }
}
