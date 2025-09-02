using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
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

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, FloatContainer floatContainer, CancellationToken cancellationToken)
        {
            owner.GetAbility<ActorBulletSystem>().SetCoolTime(coolTimeSelector.Value.GetValue(owner));
            return UniTask.CompletedTask;
        }
    }
}
