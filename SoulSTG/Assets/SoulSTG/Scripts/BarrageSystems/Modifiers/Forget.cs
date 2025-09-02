using Cysharp.Threading.Tasks;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class Forget : IBarrageModifier
    {
        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IBarrageModifier>[] modifiers;

        public UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            foreach (var modifier in modifiers)
            {
                modifier.Value.InvokeAsync(data).Forget();
            }
            return UniTask.CompletedTask;
        }
    }
}
