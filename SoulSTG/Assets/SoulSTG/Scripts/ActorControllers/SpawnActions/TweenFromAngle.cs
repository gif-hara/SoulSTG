using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class TweenFromAngle : ISpawnAction
    {
        [field: SerializeField]
        private float distance;

        [field: SerializeField]
        private float fixedAngle;

        [field: SerializeField]
        private float seconds;

        [field: SerializeField]
        private Ease ease;

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            var angle = Quaternion.Euler(0, 0, fixedAngle);
            var to = spawnedActor.transform.position + angle * spawnedActor.transform.up * distance;
            return LMotion.Create(spawnedActor.transform.position, to, seconds)
                .WithEase(ease)
                .BindToPosition(spawnedActor.transform)
                .ToUniTask(cancellationToken);
        }
    }
}
