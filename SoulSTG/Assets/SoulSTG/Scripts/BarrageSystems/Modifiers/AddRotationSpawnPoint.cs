using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using SoulSTG.ActorControllers.FloatSelectors;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class AddRotationSpawnPoint : IBarrageModifier
    {
        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IFloatSelector> rotationSelector;

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, CancellationToken cancellationToken)
        {
            spawnPoint.rotation *= Quaternion.Euler(0f, 0f, rotationSelector.Value.GetValue(owner));
            return UniTask.CompletedTask;
        }
    }
}
