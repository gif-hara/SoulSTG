using System.Threading;
using Cysharp.Threading.Tasks;
using HK;
using SoulSTG.ActorControllers;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class SpawnActor : IBarrageModifier
    {
        [field: SerializeField]
        private ActorSpawnData actorSpawnData;

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, CancellationToken cancellationToken)
        {
            return actorSpawnData.SpawnAsync(owner, spawnPoint.position, spawnPoint.rotation, cancellationToken);
        }
    }
}
