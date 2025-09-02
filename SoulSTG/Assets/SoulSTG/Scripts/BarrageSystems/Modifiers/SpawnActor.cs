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
        private Actor prefab;

        [field: SerializeField]
        private ActorSpawnActions actorModifiers;

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, CancellationToken cancellationToken)
        {
            return actorModifiers.SpawnAsync(owner, prefab, spawnPoint.position, spawnPoint.rotation, cancellationToken);
        }
    }
}
