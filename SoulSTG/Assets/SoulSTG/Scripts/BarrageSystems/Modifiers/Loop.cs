using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers.FloatSelectors;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class Loop : IBarrageModifier
    {
        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IFloatSelector> countSelector;

        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IBarrageModifier>[] modifiers;

        public async UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            var count = countSelector.Value.GetValue(new IFloatSelector.Data(data.Owner, data.FloatContainer));
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
