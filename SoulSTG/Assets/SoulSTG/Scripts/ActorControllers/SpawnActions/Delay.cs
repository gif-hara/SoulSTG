using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class Delay : ISpawnAction
    {
        [field: SerializeField]
        private float seconds;

        public async UniTask InvokeAsync(ISpawnAction.Data data)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(seconds), cancellationToken: data.CancellationToken);
        }
    }
}
