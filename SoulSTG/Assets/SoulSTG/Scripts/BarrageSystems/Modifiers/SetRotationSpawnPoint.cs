using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers.FloatSelectors;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class SetRotationSpawnPoint : IBarrageModifier
    {
        [field: SerializeField]
        private string transformName;

        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IFloatSelector> rotationSelector;

        public UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            data.Owner.Document.Q<Transform>(transformName).rotation = Quaternion.Euler(0f, 0f, rotationSelector.Value.GetValue(data.Owner));
            return UniTask.CompletedTask;
        }
    }
}
