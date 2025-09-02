using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class Loop : IBarrageModifier
    {
        [field: SerializeField, ClassesOnly]
        private int count;

        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IBarrageModifier>[] modifiers;

        public async UniTask InvokeAsync(Actor owner, Transform spawnPoint, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            for (int i = 0; i < count; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                foreach (var modifier in modifiers)
                {
                    await modifier.Value.InvokeAsync(owner, spawnPoint, floatContainer, cancellationToken);
                }
            }
        }
    }
}
