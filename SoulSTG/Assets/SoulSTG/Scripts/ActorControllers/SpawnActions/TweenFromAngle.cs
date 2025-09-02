using System;
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

        public UniTask InvokeAsync(ISpawnAction.Data data)
        {
            var fixedAngle = data.FloatContainer.Resolve(fixedAngleName);
            var distance = data.FloatContainer.Resolve(distanceName);
            var seconds = data.FloatContainer.Resolve(secondsName);
            var angle = Quaternion.Euler(0, 0, fixedAngle);
            var to = data.SpawnedActor.transform.position + angle * data.SpawnedActor.transform.up * distance;
            return LMotion.Create(data.SpawnedActor.transform.position, to, seconds)
                .WithEase(ease)
                .BindToPosition(data.SpawnedActor.transform)
                .ToUniTask(data.CancellationToken);
        }
    }
}
