using System.Threading;
using Cysharp.Threading.Tasks;
using SoulSTG.ActorControllers;
using SoulSTG.ActorControllers.Abilities;
using UnityEngine;

namespace SoulSTG.BarrageSystems.Modifiers
{
    public sealed class SetCoolTime : IBarrageModifier
    {
        [field: SerializeField]
        private float coolTime;

        public UniTask InvokeAsync(Actor owner, Transform spawnPoint, CancellationToken cancellationToken)
        {
            owner.GetAbility<ActorBulletSystem>().SetCoolTime(coolTime);
            return UniTask.CompletedTask;
        }
    }
}
