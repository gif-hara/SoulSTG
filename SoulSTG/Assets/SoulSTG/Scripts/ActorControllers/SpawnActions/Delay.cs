using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class Delay : ISpawnAction
    {
        [field: SerializeField]
        private float seconds;

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, CancellationToken cancellationToken)
        {
            return UniTask.Delay(TimeSpan.FromSeconds(seconds), cancellationToken: cancellationToken);
        }
    }
}
