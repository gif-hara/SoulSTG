using Cysharp.Threading.Tasks;
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

        public async UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            for (int i = 0; i < count; i++)
            {
                if (data.CancellationToken.IsCancellationRequested)
                {
                    break;
                }
                foreach (var modifier in modifiers)
                {
                    await modifier.Value.InvokeAsync(data);
                }
            }
        }
    }
}
