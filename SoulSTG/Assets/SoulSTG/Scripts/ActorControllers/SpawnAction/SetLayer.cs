using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK;
using UnityEngine;

namespace SoulSTG.ActorControllers.SpawnActions
{
    [Serializable]
    public sealed class SetLayer : ISpawnAction
    {
        [field: SerializeField]
        private string layerName;

        public UniTask InvokeAsync(Actor owner, Actor spawnedActor, CancellationToken cancellationToken)
        {
            spawnedActor.gameObject.SetLayerRecursively(LayerMask.NameToLayer(layerName));
            return UniTask.CompletedTask;
        }
    }
}
