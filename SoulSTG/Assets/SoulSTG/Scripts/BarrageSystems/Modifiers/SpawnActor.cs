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

        public UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            return actorModifiers.SpawnAsync(data.Owner, prefab, data.SpawnPoint.position, data.SpawnPoint.rotation, data.FloatContainer, data.CancellationToken);
        }
    }
}
