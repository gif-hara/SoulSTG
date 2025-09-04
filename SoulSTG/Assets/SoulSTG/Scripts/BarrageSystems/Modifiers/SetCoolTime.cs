using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers.Abilities;
using SoulSTG.ActorControllers.FloatSelectors;
using TNRD;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class SetCoolTime : IBarrageModifier
    {
        [field: SerializeField, ClassesOnly]
        private SerializableInterface<IFloatSelector> coolTimeSelector;

        public UniTask InvokeAsync(IBarrageModifier.Data data)
        {
            data.Owner.GetAbility<ActorBulletSystem>().SetCoolTime(coolTimeSelector.Value.GetValue(new IFloatSelector.Data(data.Owner, data.FloatContainer)));
            return UniTask.CompletedTask;
        }
    }
}
