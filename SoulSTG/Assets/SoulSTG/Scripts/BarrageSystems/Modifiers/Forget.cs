using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class Forget : IBarrageModifier
    {
        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IBarrageModifier>[] modifiers;

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, CancellationToken cancellationToken)
        {
            foreach (var modifier in modifiers)
            {
                modifier.Value.InvokeAsync(owner, spawnPoint, cancellationToken).Forget();
            }
            return UniTask.CompletedTask;
        }
    }
}
