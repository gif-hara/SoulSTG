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
        private string distanceName = "Distance";

        [field: SerializeField]
        private string fixedAngleName = "FixedAngle";

        [field: SerializeField]
        private string secondsName = "Seconds";

        [field: SerializeField]
        private Ease ease;

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            var fixedAngle = floatContainer.Resolve(fixedAngleName);
            var distance = floatContainer.Resolve(distanceName);
            var seconds = floatContainer.Resolve(secondsName);
            var angle = Quaternion.Euler(0, 0, fixedAngle);
            var to = spawnedActor.transform.position + angle * spawnedActor.transform.up * distance;
            return LMotion.Create(spawnedActor.transform.position, to, seconds)
                .WithEase(ease)
                .BindToPosition(spawnedActor.transform)
                .ToUniTask(cancellationToken);
        }
    }
}
